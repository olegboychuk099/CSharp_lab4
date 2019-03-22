using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Csharp_laba2.Model;
using Csharp_laba2.Tools;
using Csharp_laba2.Tools.Managers;

namespace Csharp_laba2.ViewModel
{
    internal class InputViewModel : ILoaderOwner
    {
        private RelayCommand<object> _proceedCommand;
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;


        public string Name { set; get; }

        public string Surname { set; get; }

        public string Email { set; get; }

        public DateTime Birthday { set; get; }
        

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(ProceedInput, CanProceedExecute));
            }
        }

        private bool CanProceedExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Surname) && !String.IsNullOrWhiteSpace(Email) && !(Birthday == default(DateTime));
        }

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }
        

        private async void ProceedInput(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            
            bool result = await Task.Run(() =>
            {
                Thread.Sleep(2000);
                try
                {
                    PersonControler.GetPerson = new Person(Name, Surname, Email, Birthday);
                }
                catch (EmailException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (PastBirthdayException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (FutureBirthdayException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (NameException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                return true;
            });

            LoaderManager.Instance.HideLoader();

            if (!result) return;

            NavigationManager.Instance.Navigate(ViewType.Output);
        }



        internal InputViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
