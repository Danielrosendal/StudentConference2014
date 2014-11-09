namespace StudentConference2014
{
    public class QuestionFreeTextViewModel : QuestionViewModelBase
    {
        private string _freeTextAnswer;

        public string FreeTextAnswer
        {
            get
            {
                return _freeTextAnswer;
            }
            set
            {
                _freeTextAnswer = value;
                OnPropertyChanged();
            }
        }
    }
}
