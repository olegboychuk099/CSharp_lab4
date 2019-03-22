using System;
using Csharp_laba2.Views;

namespace Csharp_laba2.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Input:
                    ViewsDictionary.Add(viewType, new InputView());
                    break;
                case ViewType.Output:
                    ViewsDictionary.Add(viewType, new OutputView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
