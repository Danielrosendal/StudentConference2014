using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using StudentConference2014.Annotations;
using StudentConference2014.QuestionTypes;

namespace StudentConference2014
{
    public class QuestionarieViewModel : INotifyPropertyChanged
    {
        private QuestionViewModelBase _selectedQuestion;
        private int _currentQuestionIndex;
        private QuestionIntroViewModel _firstQuestion;
        private bool _questionnaireStarted;
        private Stopwatch _stopwatch;

        public QuestionarieViewModel()
        {
            var questions = new ObservableCollection<QuestionViewModelBase>();
            _firstQuestion = new QuestionIntroViewModel();
            questions.Add(_firstQuestion);
            
            GenerateQuestionsHelper.GetQuestions(questions);
            Questions = questions;
            SelectedQuestion = Questions.ToList().ElementAt(_currentQuestionIndex);
            CanSaveQuestionnaire = true;
        }

        public bool CanSaveQuestionnaire { get; private set; }

        public bool CanStartQuestionnaire
        {
            get
            {
                return _firstQuestion.ParticipantName != null && _firstQuestion.ParticipantName.Any();
            }
        }

        public bool QuestionnaireStarted
        {
            get { return _questionnaireStarted; }
            set
            {
                _questionnaireStarted = value;
                OnPropertyChanged();
            }
        }

        public QuestionViewModelBase SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                OnPropertyChanged();
            }
        }

        #region ItemsControl

        public ObservableCollection<QuestionViewModelBase> Questions { get; private set; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void BackwardsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_currentQuestionIndex > 0)
            {
                e.CanExecute = true;
            }
        }

        public void BackwardsCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            SelectedQuestion = Questions.ToList().ElementAt(--_currentQuestionIndex);
        }

        public void ForwardCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_currentQuestionIndex < Questions.Count() - 1)
            {
                e.CanExecute = true;
            }
        }

        public void ForwardCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            if (SelectedQuestion.PreventClicks-- > 0)
            {
                return;
            }
            if (SelectedQuestion.FreezeInteractionDuration > 0)
            {
                Thread.Sleep(SelectedQuestion.FreezeInteractionDuration);
            }
            SelectedQuestion = Questions.ToList().ElementAt(++_currentQuestionIndex);
        }

        public void StartQuestionnaire()
        {
            QuestionnaireStarted = true;
            SelectedQuestion = Questions.ToList().ElementAt(++_currentQuestionIndex);
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void SaveQuestionaire()
        {
            CanSaveQuestionnaire = false;
            _stopwatch.Stop();
            var elapsedSeconds = _stopwatch.Elapsed;
            using (var file = new System.IO.StreamWriter(@"C:\StudentConferenceData\StudentConferenceSubjectData.txt", true))
            {
                var participant = _firstQuestion.ParticipantName;
                file.WriteLine("");
                file.WriteLine("Participant: " + participant);
               
                file.WriteLine("Total Time = " + elapsedSeconds + " seconds.");
            }
        }
    }
}

//foreach (var questionViewModelBase in Questions)
//{
//    if (questionViewModelBase is QuestionIntroViewModel)
//    {
//        var question = questionViewModelBase as QuestionIntroViewModel;
//        file.WriteLine("");
//        file.WriteLine("Participant: " + question.ParticipantName);
//    }
//    if (questionViewModelBase is QuestionMultiChoiceViewModel)
//    {
//        var question = questionViewModelBase as QuestionMultiChoiceViewModel;
//        var selectedAlternative = question.Alternatives.FirstOrDefault(questionAlternative => questionAlternative.IsChecked);
//        if(selectedAlternative != null)
//        {
//            file.WriteLine(selectedAlternative.Text);
//        }
//    }
//    if (questionViewModelBase is QuestionFreeTextViewModel)
//    {
//        var question = questionViewModelBase as QuestionFreeTextViewModel;
//        file.WriteLine(question.FreeTextAnswer);
//    }
//    if (questionViewModelBase is QuestionDoneViewModel)
//    {
//        var question = questionViewModelBase as QuestionDoneViewModel;
//    }
//}