using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype_full
{
    internal class StatisticsHelper
    {
        public Dictionary<Question, double> AnalyseAssignmentPerformace(Assignment assignment)
        {
            DatabaseHelper dbh = new DatabaseHelper();

            Dictionary<Question, int> questionCorrectness = dbh.PerformancePerAssignmentQuestion(assignment);

            int questionCount = questionCorrectness.Count;
            double correctnessMean = questionCorrectness.Values.Average();
            int sumOfSquares = questionCorrectness.Values.Sum(x => x * x);
            double standardDeviation = Math.Sqrt((sumOfSquares/(double)questionCount) - (correctnessMean*correctnessMean));

            Dictionary<Question, double> questionZScores = new Dictionary<Question, double>();

            foreach (KeyValuePair<Question, int> kvp in questionCorrectness)
            {
                double zScore = (kvp.Value - correctnessMean) / standardDeviation;
                double scaledZScore = zScore * (1 - (0.05 * (kvp.Key.Difficulty - 1)));
                questionZScores.Add(kvp.Key, scaledZScore);
            }

            return questionZScores;
        }

        public List<Question> GetWorstAnsweredQuestions(Dictionary<Question, double> performanceData)
        {
            return performanceData.OrderBy(x => x.Value)
                                  .ToDictionary(x => x.Key, y => y.Value).Keys
                                  .ToList();
        }

        public List<Question> GetBestAnsweredQuestions(Dictionary<Question, double> performanceData)
        {
            return performanceData.OrderByDescending(x => x.Value)
                                  .ToDictionary(x => x.Key, y => y.Value).Keys
                                  .ToList();
        }

        // if multiple topics appear, their scaled z-score should be averaged
        public Dictionary<string, double> OrganisePerformanceDataByTopic(Dictionary<Question, double> performanceData)
        {
            // aggregate z-score then divide by the times the topic appeared in the assignment to calculate an average
            Dictionary<string, double> sortingResult = new Dictionary<string, double>();
            
            foreach (KeyValuePair<Question, double> kvp in performanceData)
            {
                // if not already in this sorting list
                if (!sortingResult.ContainsKey(kvp.Key.Topic.TopicName))
                {
                    sortingResult.Add(kvp.Key.Topic.TopicName, kvp.Value);
                }
                else
                {
                    sortingResult[kvp.Key.Topic.TopicName] += kvp.Value;
                }
            }

            Dictionary<string, double> sortingResultDivided = new Dictionary<string, double>();

            foreach (KeyValuePair<string, double> kvp in sortingResult)
            {
                sortingResultDivided.Add(kvp.Key, kvp.Value / (double)performanceData.Keys.Count(x => x.Topic.TopicName == kvp.Key));
            }

            return sortingResultDivided;
        }

        public List<string> GetWorstAnsweredTopics(Dictionary<string, double> performanceData)
        {
            return performanceData.OrderBy(x => x.Value)
                                  .ToDictionary(x => x.Key, y => y.Value).Keys
                                  .ToList();
        }

        public List<string> GetBestAnsweredTopics(Dictionary<string, double> performanceData)
        {
            return performanceData.OrderByDescending(x => x.Value)
                                  .ToDictionary(x => x.Key, y => y.Value).Keys
                                  .ToList();
        }
    }
}
