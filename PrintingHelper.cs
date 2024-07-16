using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ListExtensionMethods;

using Word = Microsoft.Office.Interop.Word;
using System.Web.Caching;

namespace nea_prototype_full
{
    internal class PrintingHelper
    {
        private Question questionRef;
        private object filePath;
        private List<Image> questionImages;
        private DatabaseHelper dbh = new DatabaseHelper();

        public PrintingHelper(Question questionRef, string filePath)
        {
            this.questionRef = questionRef;
            this.filePath = filePath;
            questionImages = dbh.GetQuestionImages(questionRef);
        }

        public void PrintQuestion()
        {
            Word.Application app = new Word.Application();
            List<string> tempImagePaths = new List<string>();

            try
            {
                Word.Document document = app.Documents.Add();

                // add images
                if (questionImages.Count != 0)
                {
                    foreach (Image image in questionImages)
                    {
                        Word.Paragraph imageP = document.Content.Paragraphs.Add();

                        string tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid().ToString()}.png");
                        tempImagePaths.Add(tempPath);

                        image.Save(tempPath);

                        Word.InlineShape inlineImage = imageP.Range.InlineShapes.AddPicture(tempPath);
                    }
                }

                Word.Paragraph paragraph = document.Content.Paragraphs.Add();
                paragraph.Range.Text = BuildTextFromQuestion();
                paragraph.Range.InsertParagraphAfter();

                document.SaveAs2(filePath);
                document.Close();
                app.Quit();
            }
            finally
            {
                if (app != null) app.Quit();
            }

            // delete temp images
            foreach (string s in tempImagePaths)
            {
                if (File.Exists(s)) File.Delete(s);
            }
        }

        private string BuildTextFromQuestion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Author: {questionRef.Author.FirstName} {questionRef.Author.Surname}");
            sb.AppendLine($"Topic: {questionRef.Topic.TopicName}");
            sb.AppendLine($"Difficulty: {questionRef.Difficulty}");
            sb.AppendLine();
            sb.AppendLine(questionRef.QuestionContent);
            sb.AppendLine();

            if (questionRef.IsMc)
            {
                List<string> answers = questionRef.Answer.Union(questionRef.McAnswers).ToList().RandomiseList();

                foreach (string s in answers)
                {
                    sb.AppendLine($"☐\t{s}");
                }
            }
            else
            {
                sb.AppendLine("Answer(s): ");
            }

            return sb.ToString();
        }
    }
}
