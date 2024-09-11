using nea_prototype_full;
using api_handling_for_nea;
using ListExtensionMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace automatic_question_generation_testing
{
    internal class RandomQuestionHelper
    {
        private Random random = new Random();
        private Panel panelForDrawing;

        public Panel PanelForDrawing { get { return panelForDrawing; } set { panelForDrawing = value; } }

        public Question GenerateQuestionFromTopic(Topic topic)
        {
            int _randomInt;
            if (topic.TopicId == (int)_Topic.Quadratics)
            {
                // possible subtopics: finding roots algebraically, finding roots formulaically, expansion
                _randomInt = random.Next(1, 4);

                string equation;
                double root1;
                double root2;

                switch (_randomInt)
                {
                    case 1:

                        // determine roots, an integer 1 - 20
                        root1 = random.Next(1, 21);
                        root2 = random.Next(1, 21);

                        // form equation by Vieta's formulae
                        equation = $"x^2 - {(int)(root1 + root2)}x + {(int)(root1 * root2)}";

                        // return question
                        return new RandomlyGeneratedQuestion(topic, 2, $"Find the roots of the quadratic equation: {equation}", new List<string>() { root1.ToString(), root2.ToString() }, -1, null, $"Determine the two roots sum to the coefficient of x (i.e., α + β = {root1 + root2}), and that their product is the constant (i.e., αβ = {root1 * root2}) [1]\nFind an integer pair which produces these results -> {root1}, {root2} [1]");

                    case 2:

                        // determine quadratic coefficients, ensuring roots are non-imaginary
                        // use determinant rule to find three coefficients with one/two real roots: b^2 - 4ac >= 0
                        // find a and c first, so that b^2 can be made large enough
                        int a = random.Next(1, 21);
                        int c = random.Next(1, 21);
                        // b >= sqrt(4ac), therefore b could have to be as large as 42
                        int b = random.Next((int)Math.Ceiling(Math.Sqrt(4 * a * c)), 43);

                        equation = $"{a}x^2 + {b}x + {c}";

                        // use quadratic formula to find roots
                        root1 = Math.Round((-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a), 2);
                        root2 = Math.Round((-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a), 2);

                        // return question
                        return new RandomlyGeneratedQuestion(topic, 2, $"Find the roots of the quadratic equation: {equation}, to 2dp", new List<string>() { root1.ToString(), root2.ToString() }, -1, null, $"Form an equation to find the roots using the quadratic formula: (-{b} ± sqrt({b}^2 - 4 * {a} * {c})) / (2 * {a}) [1]\nUse a calculator to find the roots -> {root1}, {root2} [1]");

                    case 3:

                        // determine two roots, integers 1 - 20
                        root1 = random.Next(1, 21);
                        root2 = random.Next(1, 21);

                        // form answer equation by Vieta's formulae
                        equation = $"x^2 - {(int)(root1 + root2)}x + {(int)(root1 * root2)}";

                        // return question
                        return new RandomlyGeneratedQuestion(topic, 2, $"Find a quadratic with the roots: {root1} u {root2}", new List<string>() { equation }, -1, null, $"Form an equation to find the quadratic using the roots: (x - {root1})(x - {root2}) [1]\nExpand to find the equation {equation} [1]");
                }
            }
            else if (topic.TopicId == (int)_Topic.Inequalities)
            {
                // possible topics: simplify inequality, first term for which inequality pertains
                _randomInt = random.Next(1, 3);

                // for linear inequalities in the form ax + b > 0
                int a;
                int b;
                double c;
                bool sign;

                switch (_randomInt)
                {
                    case 1:

                        // determine a, integer -10-10, and b, integer 1-20
                        a = random.Next(-10, 11);
                        b = random.Next(1, 21);

                        // prevent a from being 0
                        if (a == 0) a++;

                        // students asked to simplify down to x > c, where c is a constant
                        // following flowchart:
                        c = -((double)b / (double)a);

                        // if sign is true: <, if false, >
                        sign = a < 0;

                        // return question
                        return new RandomlyGeneratedQuestion(topic, 2, $"Simplify the inequality: {a}x + {b} > 0, into the form x ? c, where c is a constant, and ? is a sign. Find c to 2dp and the sign.", new List<string>() { Math.Round(c, 2).ToString(), (sign ? "<" : ">") }, -1, null, $"Subtract the constant term from both sides, {a}x + {b} > 0 -> {a}x > {-b} [1]\nDivide each side by the x-coefficient {a}x > {-b} -> x {(sign ? '<' : '>')} {Math.Round(c, 2)} [1]");

                    case 2:

                        // determine a, integer -10-10, and b, integer 1-20
                        a = random.Next(-10, 11);
                        b = random.Next(1, 21);

                        // prevent a from being 0
                        if (a == 0) a++;

                        // following flowchart:
                        c = -((double)b / (double)a);

                        // if sign is true: <, if false, >
                        sign = a < 0;

                        // if x < c, return c - 1 or floor(c), if x > c, return c + 1 or ceil(c)
                        int firstInt;
                        if (sign)
                        {
                            // determines if a double is a whole number
                            if (Math.Truncate(c) == c) firstInt = (int)Math.Truncate(c) - 1;
                            else firstInt = (int)Math.Floor(c);
                        }
                        else
                        {
                            if (Math.Truncate(c) == c) firstInt = (int)Math.Truncate(c) + 1;
                            else firstInt = (int)Math.Ceiling(c);
                        }

                        return new RandomlyGeneratedQuestion(topic, 2, $"Find the first integer for which the inequality {a}x + {b} > 0 pertains.", new List<string>() { firstInt.ToString() }, -1, null, $"Subtract the constant term from both sides, {a}x + {b} > 0 -> {a}x > {-b} [1]\nDivide each side by the x-coefficient {a}x > {-b} -> x {(sign ? '<' : '>')} {Math.Round(c, 2)} [1]\nDetermine first integer which pertains: {firstInt} [1]");
                }
            }
            else if (topic.TopicId == (int)_Topic.SimultaneousEq)
            {
                // possible topics: find x, y

                // generate 6 integers 1-20: a,b,c,d,e,f such that: ax + by = c and dx + ey = f
                int a = random.Next(1, 21);
                int b = random.Next(1, 21);
                int c = random.Next(1, 21);
                int d = random.Next(1, 21);
                int e = random.Next(1, 21);
                int f = random.Next(1, 21);

                // ensure a unique solution exists: matrix of coefficients must be non-singular, i.e. det(M) != 0
                _2x2Matrix matrixOfCoefficients = new _2x2Matrix(new double[,] { { a, b }, { d, e } });
                // if it is, increment a
                if (matrixOfCoefficients.Det() == 0) a++;

                // if Ax = B, then x = Inverse(A)B
                _2x1Matrix result = (_2x1Matrix)matrixOfCoefficients.Inverse().MultiplyWith(new _2x1Matrix(new double[,] { { c }, { f } }));

                double x = result.Items[0, 0];
                double y = result.Items[1, 0];

                return new RandomlyGeneratedQuestion(topic, 2, $"Find the values x, y (to 2dp) which satisfy the equations:\n{a}x + {b}y = {c}\n{d}x + {e}y = {f}", new List<string>() { $"{Math.Round(x, 2)} <X>", $"{Math.Round(y, 2)} <Y>" }, -1, null, $"Find an equation for y in terms of x, then substitute this into the other equation, and solve for x -> {Math.Round(x, 2)} [1]\nRepeat for y -> {Math.Round(y, 2)} [1]");
            }
            else if (topic.TopicId == (int)_Topic.Graphs)
            {
                if (panelForDrawing == null) throw new Exception("Questions of the Graph topic require a panel for graph drawing.");

                // possible topics: find line equation, find range, find domain
                _randomInt = random.Next(1, 4);

                // graphing helper
                GraphingHelper gh;

                // either linear, quadratic, or trigonometric (basic)
                int _graphType = random.Next(1, 4);
                int _trigType = random.Next(1, 4);

                int a = random.Next(-5, 6);
                int b = random.Next(-5, 6);

                Func<double, double> function;

                switch (_graphType)
                {
                    case 1:
                        function = delegate (double x)
                        {
                            return a * x + b;
                        };
                        break;
                    case 2:
                        function = delegate (double x)
                        {
                            return (x - a) * (x - b);
                        };
                        break;
                    case 3:
                        if (_trigType == 1)
                        {
                            function = delegate (double x)
                            {
                                return Math.Sin(x);
                            };
                        }
                        else if (_trigType == 2)
                        {
                            function = delegate (double x)
                            {
                                return Math.Cos(x);
                            };
                        }
                        else
                        {
                            function = delegate (double x)
                            {
                                return Math.Tan(x);
                            };
                        }
                        break;
                    default:
                        function = delegate (double x) { return x; };
                        break;
                }

                Bitmap graphImage;

                switch (_randomInt)
                {
                    case 1:

                        gh = new GraphingHelper(function, 0.1, -10, 10, panelForDrawing, 20, 20);

                        // plot and export image
                        (graphImage, _) = gh.PlotFunction();

                        string equation = string.Empty;
                        if (_graphType == 1) equation = $"{a}x + {b}";
                        else if (_graphType == 2) equation = $"(x-{a})(x-{b})";
                        else
                        {
                            if (_trigType == 1) equation = "sin(x)";
                            if (_trigType == 2) equation = "cos(x)";
                            if (_trigType == 3) equation = "tan(x)";
                        }

                        RandomlyGeneratedQuestion question = new RandomlyGeneratedQuestion(topic, 2, $"Find the equation of the displayed graph as a function of x.", new List<string>() { equation }, -1, null, $"No description for this question.");
                        question.AttachImage(graphImage);
                        return question;

                    case 2:

                        gh = new GraphingHelper(function, 0.1, -10, 10, panelForDrawing, 20, 20);
                        List<PointD> points;

                        // plot and export image
                        (graphImage, points) = gh.PlotFunction();
                        (double min, double max) = gh.GetRangeFromPoints(points);

                        RandomlyGeneratedQuestion question2 = new RandomlyGeneratedQuestion(topic, 2, $"Find the range of the given graph, giving your answer as a min and max to 1dp.", new List<string>() { Math.Round(min, 1).ToString(), Math.Round(max, 1).ToString() }, -1, null, $"The range refers to the outcome of f(x), look for the minimum and maximum values of y within this domain -> min: {Math.Round(min, 1)}, max: {Math.Round(max, 1)}. [2]");
                        question2.AttachImage(graphImage);
                        return question2;

                    case 3:

                        int domain = random.Next(1, 10);

                        gh = new GraphingHelper(function, 0.1, -domain, domain, panelForDrawing, 20, 20);

                        // plot and export image
                        (graphImage, _) = gh.PlotFunction();

                        RandomlyGeneratedQuestion question3 = new RandomlyGeneratedQuestion(topic, 2, $"Find the domain of the given graph, giving your answer as an integer α, such that the range is -α < x < α.", new List<string>() { domain.ToString() }, -1, null, $"The range refers to the input of f(x), look for the minimum and maximum values of x -> α: {domain}. [1]");
                        question3.AttachImage(graphImage);
                        return question3;
                }

            }
            else if (topic.TopicId == (int)_Topic.SubjectVerbAgreement)
            {
                // use news article api to generate sample sva sentences
                NewsQuestionHelper nqh = new NewsQuestionHelper();
                List<(string title, string content)> articles = nqh.NewsArticleQuestion();
                (string correctTitle, string correctContent) = articles.First();

                // remove first, add last 3 to mca
                articles.RemoveAt(0);

                RandomlyGeneratedQuestion rgq = new RandomlyGeneratedQuestion(topic, 2, $"Which of the following article titles best matches the article content?\n\n{correctContent}", new List<string> { correctTitle }, -1, null, "No answer key provided for this question.");
                rgq.ForceMc(articles.Select(x => x.title).ToList());
                return rgq;
            }
            else if (topic.TopicId == (int)_Topic.AdjectivesAdverbs)
            {
                // use thesaurus api
                _randomInt = random.Next(1, 3);

                // chooses random: noun, adjectice, verb
                _WordType wordType = (_WordType)new Random().Next(0, 3);
                ThesaurusQuestionHelper tqh = new ThesaurusQuestionHelper(wordType);
                string word = tqh.WordInput;

                switch (_randomInt)
                {
                    case 1:

                        (string[] words, int synIndex) = tqh.SynAntQuestion().Result;

                        RandomlyGeneratedQuestion rgq = new RandomlyGeneratedQuestion(topic, 1, $"Which of the following words is a synonym of: {word}?", new List<string> { words[synIndex] }, -1, null, "No answer key available for this question.");

                        // remove syn and keep antonyms
                        List<string> nonSyns = words.ToList();
                        nonSyns.RemoveAt(synIndex);

                        // remove duplicates
                        nonSyns.Distinct();

                        rgq.ForceMc(nonSyns);
                        return rgq;

                    case 2:

                        List<string> defs = tqh.DefinitionMatchQuestion(wordType).Result;
                        RandomlyGeneratedQuestion rgq2 = new RandomlyGeneratedQuestion(topic, 1, $"Which of the following provides the best definition of the word: {word}?", new List<string> { defs.First() }, -1, null, "No answer key available for this question.");
                        
                        // remove first (correct) definition and push to mc answers
                        defs.RemoveAt(0);

                        rgq2.ForceMc(defs);
                        return rgq2;
                }
            }
            throw new Exception("No randomly generated questions available for this topic.");
        }
    }
}
