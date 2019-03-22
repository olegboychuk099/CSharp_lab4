using Csharp_laba2.Model;
using Csharp_laba2.Tools;
using Csharp_laba2.Tools.Managers;

namespace Csharp_laba2.ViewModel
{
    internal class OutputViewModel
    {
        private RelayCommand<object> _backCommand;
        private readonly Person _person = PersonControler.GetPerson;

        public string Output
        {
            get
            {
                return _person.ToString();
            }
        }
        public string Birthday
        {
            get
            {
                return _person.IsBirthDay ? "🎈🎁Happy Birthday🎁🎈" : "";
            }
        }

        public RelayCommand<object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.Input);
                           }
                ));
            }
        }
    }
}
