using System.Collections.ObjectModel;

namespace StudentConference2014
{
    public class QuestionMultiChoiceViewModel : QuestionViewModelBase
    {
        private ObservableCollection<QuestionAlternativeViewModel> _alternatives;
        private QuestionAlternativeViewModel _selectedAlternative;

        public QuestionMultiChoiceViewModel()
        {
            _alternatives = new ObservableCollection<QuestionAlternativeViewModel>();
        }

        public QuestionAlternativeViewModel SelectedAlternative
        {
            get { return _selectedAlternative; }
            set
            {
                _selectedAlternative = value;
                OnPropertyChanged();
            } }

        public ObservableCollection<QuestionAlternativeViewModel> Alternatives
        {
            get { return _alternatives; }
            set
            {
                _alternatives = value;
                OnPropertyChanged();
            }
        }
    }
}
