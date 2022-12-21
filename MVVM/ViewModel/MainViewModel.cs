using SuperChat.Core;
using SuperChat.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperChat.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }

        public ObservableCollection<ContactModel> Contacts { get; set; } 


        /* Commands */

        public RelayCommand SendCommand{ get; set; }

        private ContactModel _selectedContact;


        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";

            });

            Messages.Add(new MessageModel
            {
                Username = "Allison",
                UsernameColor = "#409aff",
                ImageSource = "",
                Message = "Test",
                Time = DateTime.Now,
                isNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Allison",
                    UsernameColor = "#409aff",
                    ImageSource = "https://randomuser.me/api/portraits/men/11.jpg",
                    Message = "Test",
                    Time = DateTime.Now,
                    isNativeOrigin = false,
                    FirstMessage = false
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Bunny",
                    UsernameColor = "#409aff",
                    ImageSource = "https://randomuser.me/api/portraits/men/11.jpg", /* To change user images here */
                    Message = "Test",
                    Time = DateTime.Now,
                    isNativeOrigin = true,

                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Bunny",
                UsernameColor = "#409aff",
                ImageSource = "https://randomuser.me/api/portraits/men/11.jpg",
                Message = "Last",
                Time = DateTime.Now,
                isNativeOrigin = true,
            });

            for (int i = 0; i < 5; i++)
            {
              Contacts.Add(new ContactModel
              {
                  Username = $"Allison {i}",
                  ImageSource = "https://randomuser.me/api/portraits/men/11.jpg",
                  Messages = Messages

              });
            }
        }
    }
}
