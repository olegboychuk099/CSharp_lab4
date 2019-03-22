using System.Windows;
using System.Windows.Controls;
using Csharp_laba2.Tools;
using Csharp_laba2.Tools.Managers;
using Csharp_laba2.Tools.Navigation;

namespace Csharp_laba2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Input);
        }
    }
}
