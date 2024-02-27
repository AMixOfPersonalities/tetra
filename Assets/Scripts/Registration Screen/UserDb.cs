using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank
{
    public class UserDb : SqliteHelper
    {
        private const String Tag = "Tetra: UserDb:\t";

        private const String TABLE_NAME = "User";
        private const String KEY_USER = "user";
        private const String KEY_HASH = "hash";
        private const String KEY_EMAIL = "email";
        private const String KEY_DATE = "date";
        private String[] COLUMNS = new String[] { KEY_USER, KEY_HASH, KEY_EMAIL, KEY_DATE };

        public UserDb() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_USER + " TEXT, " +
                KEY_HASH + " TEXT, " +
                KEY_EMAIL + " TEXT, " +
                KEY_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(UserEntity user)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_USER + ", "
                + KEY_HASH + ", "
                + KEY_EMAIL + " ) "

                + "VALUES ( '"
                + user._user + "', '"
                + user._hash + "', '"
                + user._email + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataByString(string str)
        {
            Debug.Log(Tag + "Getting User: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_USER + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public override void deleteDataByString(string id)
        {
            Debug.Log(Tag + "Deleting User: " + id);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_USER + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

        public override void deleteAllData()
        {
            Debug.Log(Tag + "Deleting Table");

            base.deleteAllData(TABLE_NAME);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }


        public IDataReader getLatestTimeStamp()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " ORDER BY " + KEY_DATE + " DESC LIMIT 1";
            return dbcmd.ExecuteReader();
        }
    }
}