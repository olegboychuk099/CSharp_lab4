using System.Windows.Controls;
using Csharp_laba2.Tools;
using Csharp_laba2.ViewModel;

namespace Csharp_laba2.Views
{
    /// <summary>
    /// Interaction logic for OutputView.xaml
    /// </summary>
    public partial class OutputView : UserControl, INavigatable
    {
        public OutputView()
        {
            InitializeComponent();
            DataContext = new OutputViewModel();
        }
    }
}
