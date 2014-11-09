using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Controls;
using StudentConference2014.QuestionTypes;

namespace StudentConference2014
{
    public static class GenerateQuestionsHelper
    {
        public static ObservableCollection<QuestionViewModelBase> GetQuestions(ObservableCollection<QuestionViewModelBase> questionList)
        {
            GenerateQuestionsFromFile(questionList);
            questionList.Add(new QuestionDoneViewModel());
            return questionList;
        }

        private static void GenerateQuestionsFromFile(ObservableCollection<QuestionViewModelBase> questionList)
        {
            using (StreamReader sr = new StreamReader(@"C:\StudentConferenceData\Questions.txt", Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //var line = sr.ReadLine();
                    //if (line == null)
                    //{
                    //    linesLeft = false;
                    //    return; 
                    //}
                    if (line.CompareTo("F") == 0)
                    {
                        questionList.Add(new QuestionFreeTextViewModel
                        {
                            Text = sr.ReadLine()
                        });
                    }
                    else if(line.CompareTo("M") == 0)
                    {
                        var questionText = sr.ReadLine();
                        var alternativeCollection = new ObservableCollection<QuestionAlternativeViewModel>();
                        string alternativeLine;
                        while ((alternativeLine = sr.ReadLine()).CompareTo("E") != 0)
                        {
                            alternativeCollection.Add(new QuestionAlternativeViewModel
                            {
                                Text = alternativeLine
                            });
                        }
                        questionList.Add(new QuestionMultiChoiceViewModel
                        {
                            Text = questionText,
                            Alternatives = alternativeCollection
                        });
                    }
                }
                //String line = sr.ReadLine()
                //foreach (var VARIABLE in COLLECTION)
                //{
                    
                //}
                //Console.WriteLine(line);
            }
        }
    }
}
