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
        // assignment performance analysis

        /// <summary>
        /// Analyses student performance on an assignment by calculating the scaled z-scores for correctness.
        /// This method adjusts scores based on difficulty and returns a dictionary of questions mapped to their scaled performance values.
        /// </summary>
        /// <param name="assignment"></param>
        /// <returns>A dictionary of questions mapped to their scaled performance values.</returns>
        public Dictionary<Question, double> AnalyseAssignmentPerformace(Assignment assignment)
        {
            DatabaseHelper dbh = new DatabaseHelper();

            Dictionary<Question, int> questionCorrectness = dbh.PerformancePerAssignmentQuestion(assignment);

            // calculate standard deviation
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

        /// <summary>
        /// Retrieves a list of questions that were answered the worst based on performance scores.
        /// </summary>
        /// <param name="performanceData"></param>
        /// <returns>A list of questions sorted in ascending order of performance (worst first).</returns>
        public List<Question> GetWorstAnsweredQuestions(Dictionary<Question, double> performanceData)
        {
            return performanceData.OrderBy(x => x.Value)
                                  .ToDictionary(x => x.Key, y => y.Value).Keys
                                  .ToList();
        }

        /// <summary>
        /// Retrieves a list of questions that were answered the best based on performance scores.
        /// </summary>
        /// <param name="performanceData"></param>
        /// <returns>A list of questions sorted in descending order of performance (best first).</returns>
        public List<Question> GetBestAnsweredQuestions(Dictionary<Question, double> performanceData)
        {
            return performanceData.OrderByDescending(x => x.Value)
                                  .ToDictionary(x => x.Key, y => y.Value).Keys
                                  .ToList();
        }

        // if multiple topics appear, their scaled z-score should be averaged

        /// <summary>
        /// A method which aggregates performance data by topic by averaging the scaled z-scores for each topic.
        /// </summary>
        /// <param name="performanceData"></param>
        /// <returns>A dictionary mapping topic names to their averaged performance scores.</returns>
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

        /// <summary>
        /// Retrieves a list of topics that were answered the worst based on performance scores.
        /// </summary>
        /// <param name="performanceData"></param>
        /// <returns>A list of topic names sorted in ascending order of performance (worst first).</returns>
        public List<string> GetWorstAnsweredTopics(Dictionary<string, double> performanceData)
        {
            return performanceData.OrderBy(x => x.Value)
                                  .ToDictionary(x => x.Key, y => y.Value).Keys
                                  .ToList();
        }

        /// <summary>
        /// Retrieves a list of topics that were answered the best based on performance scores.
        /// </summary>
        /// <param name="performanceData"></param>
        /// <returns>A list of topic names sorted in descending order of performance (best first).</returns>
        public List<string> GetBestAnsweredTopics(Dictionary<string, double> performanceData)
        {
            return performanceData.OrderByDescending(x => x.Value)
                                  .ToDictionary(x => x.Key, y => y.Value).Keys
                                  .ToList();
        }

        /// <summary>
        /// Retrieves a list of topics that were answered the worst based on performance scores.
        /// </summary>
        /// <param name="performanceData"></param>
        /// <returns>A list of topic names sorted in ascending order of performance (worst first).</returns>
        public List<int> GetWorstAnsweredTopics(Dictionary<int, double> performanceData)
        {
            return performanceData.OrderBy(x => x.Value)
                                  .ToDictionary(x => x.Key, y => y.Value).Keys
                                  .ToList();
        }

        /// <summary>
        /// Retrieves a list of topics that were answered the best based on performance scores.
        /// </summary>
        /// <param name="performanceData"></param>
        /// <returns>A list of topic names sorted in descending order of performance (best first).</returns>
        public List<int> GetBestAnsweredTopics(Dictionary<int, double> performanceData)
        {
            return performanceData.OrderByDescending(x => x.Value)
                                  .ToDictionary(x => x.Key, y => y.Value).Keys
                                  .ToList();
        }

        // student performance analysis

        /// <summary>
        /// A method which scales question correctness score based on difficulty. Correct answers receive a scaled score, while incorrect answers receive a score of 0.
        /// </summary>
        /// <param name="wasCorrect"></param>
        /// <param name="difficulty"></param>
        /// <returns>A scaled correctness score (double) between 0 and 1.</returns>
        public double ScaleCorrectness(bool wasCorrect, int difficulty)
        {
            // if incorrect do not scale
            if (!wasCorrect) return 0.0;
            else
            {
                // otherwise scale based on difficulty, see 1.6.4
                return 0.8 + 0.2 * ((difficulty - 1) / 3.0);
            }
        }

        /// <summary>
        /// A method which scales the time spent answering a question based on the question's length and type (e.g., multiple choice or free input).
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="questionLength"></param>
        /// <param name="questionType"></param>
        /// <returns>A scaled time score (double) adjusted for question characteristics.</returns>
        public double ScaleQuestionTime(int seconds, int questionLength, _QuestionType questionType)
        {
            const double a = 1.2;
            const double b = 0.01;
            const double c = 1.0;
            const double d = 0.01;

            // logarithmic scaling, see 1.6.4
            if (questionType == _QuestionType.MultipleChoice)
            {
                return seconds / (a * Math.Log(b * questionLength + 1));
            }
            else
            {
                return seconds / (c * Math.Log(d * questionLength + 1));
            }
        }

        /// <summary>
        /// A method which converts a pseudotopic (from enum) to a proper topic object.
        /// </summary>
        /// <param name="pseudotopic"></param>
        /// <returns>A topic (Topic object) representation of the pseudotopic.</returns>
        public Topic GetTopicFromPseudotopic(_Topic pseudotopic)
        {
            int subjectId = (int)pseudotopic <= 8 ? 1 : 2;
            return new Topic((int)pseudotopic, null, null, new Subject(subjectId, null));
        }

        /// <summary>
        /// A method which aggregates and averages the performance scores for topics. If a topic appears multiple times, its scores are summed and averaged.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A dictionary mapping topic IDs to their averaged performance scores.</returns>
        public Dictionary<int, double> AggregateAndAverageTopics(Dictionary<Topic, double> input)
        {
            Dictionary<int, double> sortingResult = new Dictionary<int, double>();

            foreach (KeyValuePair<Topic, double> kvp in input)
            {
                // if not already in this sorting list
                if (!sortingResult.ContainsKey(kvp.Key.TopicId))
                {
                    sortingResult.Add(kvp.Key.TopicId, kvp.Value);
                }
                else
                {
                    sortingResult[kvp.Key.TopicId] += kvp.Value;
                }
            }

            Dictionary<int, double> sortingResultDivided = new Dictionary<int, double>();

            foreach (KeyValuePair<int, double> kvp in sortingResult)
            {
                sortingResultDivided.Add(kvp.Key, kvp.Value / (double)input.Keys.Count(x => x.TopicId == kvp.Key));
            }

            return sortingResultDivided;
        }

        /// <summary>
        /// A method which takes in a list of a student's question attempts and returns the scaled averaged correctness and time spent per topic.
        /// </summary>
        /// <param name="questionAttempts"></param>
        /// <returns>A tuple containing: a topic ID, an average of scaled topic correctness, and an average of scaled time per topic</returns>
        private List<Tuple<int, double, double>> OrganiseStudentQuestionAttempts(List<QuestionAttempt> questionAttempts)
        {
            // average both criteria for each topic

            List<Tuple<int, double, double>> result = new List<Tuple<int, double, double>>();

            Dictionary<Topic, double> topicVsCorrectness = new Dictionary<Topic, double>();
            Dictionary<Topic, double> topicVsTime = new Dictionary<Topic, double>();

            foreach (QuestionAttempt questionAttempt in questionAttempts)
            {
                // if rgq
                if (questionAttempt.Question == null)
                {
                    // default all rgq difficulties to 2
                    topicVsCorrectness.Add(GetTopicFromPseudotopic(questionAttempt.Pseudotopic), ScaleCorrectness(questionAttempt.WasCorrect, 2));
                }
                else
                {
                    topicVsCorrectness.Add(questionAttempt.Question.Topic, ScaleCorrectness(questionAttempt.WasCorrect, questionAttempt.Question.Difficulty));
                }

                TimeSpan timeDifference;
                if (questionAttempt.TimeQuestionOpened == null)
                {
                    // if unavailable, default to 1 minute
                    timeDifference = new TimeSpan(0, 1, 0);
                }
                else
                {
                    timeDifference = questionAttempt.TimeOfAttempt.Subtract(questionAttempt.TimeQuestionOpened);
                }

                // if rgq
                if (questionAttempt.Question == null)
                {
                    // all rgqs are free input, as no question length recorded default to 50 characters
                    topicVsTime.Add(GetTopicFromPseudotopic(questionAttempt.Pseudotopic), ScaleQuestionTime((int)Math.Floor(timeDifference.TotalSeconds), 50, _QuestionType.FreeInput));
                }
                else
                {
                    _QuestionType questionType = questionAttempt.Question.IsMc ? _QuestionType.MultipleChoice : _QuestionType.FreeInput;
                    topicVsTime.Add(questionAttempt.Question.Topic, ScaleQuestionTime((int)Math.Floor(timeDifference.TotalSeconds), questionAttempt.Question.QuestionContent.Length, questionType));
                }
            }

            Dictionary<int, double> topicVsCorrectnessAverage = AggregateAndAverageTopics(topicVsCorrectness);
            Dictionary<int, double> topicVsTimeAverage = AggregateAndAverageTopics(topicVsTime);

            foreach (int topicId in topicVsCorrectnessAverage.Keys)
            {
                result.Add(new Tuple<int, double, double>(topicId, topicVsCorrectnessAverage[topicId], topicVsTimeAverage[topicId]));
            }

            return result;
        }

        /// <summary>
        /// A method which analyses a student's question and attempts to calculate a combined performance score for each topic. Normalises scaled correctness and time using z-scores, aggregates them, and returns a topic performance analysis.
        /// </summary>
        /// <param name="questionAttempts"></param>
        /// <returns>A dictionary mapping topic IDs to their aggregated performance scores.</returns>
        public Dictionary<int, double> AnalyseStudentQuestionAttempts(List<QuestionAttempt> questionAttempts)
        {
            List<Tuple<int, double, double>> organisedPerformance = OrganiseStudentQuestionAttempts(questionAttempts);

            int topicCount = organisedPerformance.Count;

            // correctness
            double correctnessMean = organisedPerformance.Select(x => x.Item2).Average();
            double sumOfSquaresCorrectness = organisedPerformance.Sum(x => x.Item2 * x.Item2);
            double standardDeviationCorrectness = Math.Sqrt((sumOfSquaresCorrectness / (double)topicCount) - (correctnessMean * correctnessMean));

            // time
            double timeMean = organisedPerformance.Select(x => x.Item3).Average();
            double sumOfSquaresTime = organisedPerformance.Sum(x => x.Item3 * x.Item3);
            double standardDeviationTime = Math.Sqrt((sumOfSquaresTime / (double)topicCount) - (timeMean * timeMean));

            Dictionary<int, double> topicAnalysis = new Dictionary<int, double>();

            foreach (Tuple<int, double, double> tuple in organisedPerformance)
            {
                double correctnessZScore = (tuple.Item2 - correctnessMean) / standardDeviationCorrectness;
                double timeZScore = (tuple.Item3 - timeMean) / standardDeviationTime;
                topicAnalysis.Add(tuple.Item1, correctnessZScore + (-timeZScore));
            }

            return topicAnalysis;
        }
    }
}
