using System.Windows.Controls;
using Csharp_laba2.Tools;
using Csharp_laba2.ViewModel;

namespace Csharp_laba2.Views
{
    /// <summary>
    /// Interaction logic for Input.xaml
    /// </summary>
    public partial class InputView : UserControl, INavigatable
    {
        public InputView()
        {
            InitializeComponent();
            DataContext = new InputViewModel();
        }
    }
}
