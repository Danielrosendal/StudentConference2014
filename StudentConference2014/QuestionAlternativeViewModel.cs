using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudentConference2014.Annotations;

namespace StudentConference2014
{
    public class QuestionAlternativeViewModel : INotifyPropertyChanged
    {
        private bool _isChecked;
        private string _text;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value; 
                OnPropertyChanged();
            }
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
