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
    internal class NewsApiHandling
    {
        private string topic;

        public string Topic { get { return topic; } set { this.topic = value; } }

        public NewsApiHandling(string topic)
        {
            this.topic = topic;
        }

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
        /// <returns></returns>
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

        private string GetRandomPredefTopic()
        {
            return predefTopics[new Random().Next(predefTopics.Length)];
        }
    }
}
