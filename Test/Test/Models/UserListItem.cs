using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace Test.Models
{
    public class UserListItem : PropertyChangedBase
    {

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value != _userName)
                {
                    _userName = value;
                    NotifyOfPropertyChange(() => UserName);
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    NotifyOfPropertyChange(() => Password);
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyOfPropertyChange(() => Name);
                }
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value != _surname)
                {
                    _surname = value;
                    NotifyOfPropertyChange(() => Surname);
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    NotifyOfPropertyChange(() => Email);
                }
            }
        }

    }
}
