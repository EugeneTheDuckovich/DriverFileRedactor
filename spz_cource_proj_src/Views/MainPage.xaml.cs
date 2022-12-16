using spz_cource_proj_src.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace spz_cource_proj_src.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Frame _mainFrame;

        private event Func<bool> _openFileCommandEvent;

        public MainPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            var mainViewModel = new MainViewModel(_mainFrame);
            _openFileCommandEvent += mainViewModel.OpenFile;
            DataContext = mainViewModel;
        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            if (PathTextBox.IsFocused) 
            {
                _openFileCommandEvent.Invoke();
            }
        }
    }
}
