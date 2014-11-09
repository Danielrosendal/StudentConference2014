using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentConference2014
{
    public partial class MainWindow : Window
    {
        private QuestionarieViewModel _questionarieViewModel = new QuestionarieViewModel();

        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = _questionarieViewModel;
        }

        private void BackwardsCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            _questionarieViewModel.BackwardsCommand_Execute(sender, e);
        }

        private void BackwardsCommand_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            _questionarieViewModel.BackwardsCommand_CanExecute(sender, e);
        }

        private void ForwardCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            _questionarieViewModel.ForwardCommand_Execute(sender, e);
        }

        private void ForwardCommand_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            _questionarieViewModel.ForwardCommand_CanExecute(sender, e);
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _questionarieViewModel.SaveQuestionaire();
        }

        private void SaveCommand_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _questionarieViewModel.CanSaveQuestionnaire;
        }

        private void StartQuestionnaire_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _questionarieViewModel.StartQuestionnaire();
        }

        private void StartQuestionnaire_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var canExecute =_questionarieViewModel.CanStartQuestionnaire;
            e.CanExecute = canExecute;
        }
    }
}
