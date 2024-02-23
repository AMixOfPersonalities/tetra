using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
    public class LocationEntity
    {

        public string _user;
        public string _hash;
        public string _email;
        public String _dateCreated;

        public LocationEntity(string user, string hash, string email)
        {
            _user = user;
            _hash = hash;
            _email = email;
            _dateCreated = "";
        }

        public LocationEntity(string user, string hash, string email, string dateCreated)
        {
            _user = user;
            _hash = hash;
            _email = email;
            _dateCreated = dateCreated;
        }

        public static LocationEntity getFakeLocation()
        {
            return new LocationEntity("user", "hash", "email@example.com");
        }
    }