using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
    public class UserEntity
    {

        public string _user;
        public string _hash;
        public string _email;
        public String _dateCreated;

        public UserEntity(string user, string hash, string email)
        {
            _user = user;
            _hash = hash;
            _email = email;
            _dateCreated = "";
        }

        public UserEntity(string user, string hash, string email, string dateCreated)
        {
            _user = user;
            _hash = hash;
            _email = email;
            _dateCreated = dateCreated;
        }

        public static UserEntity getFakeUser()
        {
            return new UserEntity("user", "hash", "email@example.com");
        }
    }
}