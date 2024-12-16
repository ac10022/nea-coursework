using System;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace api_handling_for_nea
{
    /// <summary>
    /// A class to handle english comprehension questions which require headlines: this API, NewsAPI provides access to current news articles, which are fetched using this class.
    /// </summary>
    internal class NewsApiHandling
    {
        private string topic;

        public string Topic { get { return topic; } set { this.topic = value; } }

        public NewsApiHandling(string topic)
        {
            this.topic = topic;
        }

        /// <summary>
        /// A method to fetch articles with the constructor specified topic.
        /// </summary>
        /// <returns>A list of articles (NewsAPI Article objects).</returns>
        /// <exception cref="Exception"></exception>
        public List<Article> Execute()
        {
            if (topic == null) throw new Exception("No topic for NewsAPI specified");

            NewsApiClient apiClient = new NewsApiClient("ae3e2a94556949159ed8555093bc6a96");
            ArticlesResult response = FetchArticles(topic, apiClient);

            if (response.Status == Statuses.Ok)
            {
                return SanitiseArticles(response.Articles);
            }
            else
            {
                throw new Exception($"{response.Error.Code} => {response.Error.Message}");
            }
        }

        /// <summary>
        /// A method which fetches articles, given a topic and a client. All articles in english from the last month are fetched.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="apiClient"></param>
        /// <returns>An articles result object (NewsAPI), articles fetched by using the Articles attribute.</returns>
        private ArticlesResult FetchArticles(string topic, NewsApiClient apiClient)
        {
            return apiClient.GetEverything(new EverythingRequest
            {
                Q = topic,
                Language = NewsAPI.Constants.Languages.EN,
                SortBy = SortBys.Relevancy,
                From = DateTime.Today.AddDays(-27)
            });
        }

        /// <summary>
        /// A method to sanitise the raw articles HTML markup to sanitised strings to use within questions.
        /// </summary>
        /// <param name="articles"></param>
        /// <returns>A list of sanitised articles (NewsAPI Article objects)</returns>
        private List<Article> SanitiseArticles(List<Article> articles)
        {
            List<Article> result = new List<Article>();
            foreach (Article article in articles)
            {
                // remove if article is no longer available/content is cookie message
                if (article.Title == @"[Removed]") continue;
                if (article.Content.Contains("Accept all")) continue;

                // remove title from content
                article.Content.Replace(article.Title, "");

                // remove [+X chars]
                article.Content = new Regex(@"\[.+\]").Replace(article.Content, "");
                // remove html tags
                article.Content = new Regex(@"<.+?>").Replace(article.Content, "");

                // remove new lines
                article.Content = article.Content.Replace(Environment.NewLine, "");

                // article doesn't end
                article.Content += "...";

                result.Add(article);
            }
            return result;
        }
    }

    /// <summary>
    /// A class to construct questions from articles fetched using the NewsApiHandling class.
    /// </summary>
    public class NewsQuestionHelper
    {
        private string topic;
        private string[] predefTopics = { "Education", "Work", "Technology", "Immigration", "Media", "Culture", "Business", "Communication", "Environment", "Family", "Society", "Technology", "Travel", "Sport", "Lifestyle" };

        public NewsQuestionHelper(string topic = null)
        {
            if (topic == null) this.topic = GetRandomPredefTopic();
            else this.topic = topic;
        }

        /// <summary>
        /// Get an array of 4 random news articles (title and content), with the first always relating best to the topic given.
        /// </summary>
        /// <returns>A list of tuples: article name, article content. The first item of the list is the "correct" answer.</returns>
        public List<(string title, string content)> NewsArticleQuestion()
        {
            List<(string title, string content)> result = new List<(string title, string content)>();
            NewsApiHandling nah = new NewsApiHandling(topic);
            Article article = nah.Execute().First();
            result.Add((article.Title, article.Content));

            for (int i = 0; i < 3; i++)
            {
                nah.Topic = GetRandomPredefTopic();
                article = nah.Execute().First();
                result.Add((article.Title, article.Content));
            }

            return result;
        }

        /// <summary>
        /// A method to fetch a random topic from the list of predefined topics.
        /// </summary>
        /// <returns></returns>
        private string GetRandomPredefTopic()
        {
            return predefTopics[new Random().Next(predefTopics.Length)];
        }
    }
}
