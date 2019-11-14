using System.Windows;
using System.Windows.Input;

using Starter.Data.ViewModels;
using Starter.Data.Interfaces.Repositories;

namespace Starter.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        protected MainViewModel ViewModel;

        public MainWindow(ICatRepository repository)
        {
            _repository = repository;

            InitializeComponent();
            
            ViewModel = new MainViewModel(repository);

            DataContext = ViewModel;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ResetSelected();
            CatName.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Delete();
        }

        private void CatName_OnKeyUp(object sender, KeyEventArgs e)
        {
            //ViewModel.IsSaveVisible = Visibility.Hidden;

            //if (!string.IsNullOrEmpty(CatName.Text.Trim()))
            //{
            //    ViewModel.IsSaveVisible = Visibility.Visible;
            //}
        }

        private readonly ICatRepository _repository;
    }
}