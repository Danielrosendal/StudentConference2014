using System.Windows;
using System.Windows.Controls;
using StudentConference2014.QuestionTypes;

namespace StudentConference2014
{
    public class QuestionDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (item is QuestionIntroViewModel)
            {
                return element.FindResource("c_questionnaireIntro") as DataTemplate;
            }
            if (item is QuestionMultiChoiceViewModel)
            {
                return element.FindResource("c_multiAnswerQuestion") as DataTemplate;
            }
            if (item is QuestionFreeTextViewModel)
            {
                return element.FindResource("c_freeTextQuestion") as DataTemplate;
            }
            if (item is QuestionDoneViewModel)
            {
                return element.FindResource("c_questionnaireDone") as DataTemplate;
            }
            return null;
        }
    }
}
