
namespace Csharp_laba2.Tools
{
    internal enum ViewType
    {
       Input,
       Output,
    }

    internal interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
