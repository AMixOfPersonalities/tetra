using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using TMPro;
using UnityEngine.SceneManagement;

public class UserDbTest : MonoBehaviour
{
    public TMP_Text errorMessage; 
    public void ReadUserDb()
    {
        UserDb mUserDb = new UserDb();

        System.Data.IDataReader reader = mUserDb.getAllData();
        int fieldCount = reader.FieldCount;
        List<UserEntity> myList = new List<UserEntity>();
        while (reader.Read())
        {
            UserEntity entity = new UserEntity(
                reader[0].ToString(),
                reader[1].ToString(),
                reader[2].ToString(),
                reader[3].ToString()
                );

            Debug.Log(entity._user + " " + entity._hash + " " + entity._email + " " + entity._dateCreated);
            myList.Add(entity);
        }
    }

    public void AddEntryUserDb(string user, string hash, string email)
    {
        UserDb mUserDb = new UserDb();

        // Check if the username already exists in the database
        if (IsUsernameExists(user))
        {
            // Prompt the user to enter a new username
            errorMessage.text = "Username already exists. Please enter a new username.";
            errorMessage.color = Color.red;
            return;
        }

        // Add the user to the database
        mUserDb.addData(new UserEntity(user, hash, email));
        Debug.Log("User added successfully.");
        SceneManager.LoadScene("Scene1 - Start Screen");
    }

    private bool IsUsernameExists(string username)
    {
        UserDb mUserDb = new UserDb();
        System.Data.IDataReader reader = mUserDb.getDataByString(username);

        // If any data is returned, the username already exists
        return reader.Read();
    }
}
