using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using StudentConference2014.Annotations;

namespace StudentConference2014
{
    public abstract class QuestionViewModelBase : INotifyPropertyChanged
    {
        private string _text;
        
        private static int _questionNumber;
        private readonly int _instanceQuestionNumber;

        public QuestionViewModelBase()
        {
            _instanceQuestionNumber = _questionNumber++;
        }

        public string Header
        {
            get { return _instanceQuestionNumber.ToString(CultureInfo.InvariantCulture); }
        }

        protected QuestionViewModelBase(string text)
        {
            _text = text;
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public bool HasAnswer { get; set; }

        public int PreventClicks { get; set; }

        public int FreezeInteractionDuration { get; set; }

        public int TimeToQuestionCompletion { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
