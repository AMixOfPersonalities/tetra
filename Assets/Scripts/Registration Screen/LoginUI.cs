using System.Collections;
using System.Collections.Generic;
using DataBank;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginUI : MonoBehaviour
{
    public MD5Script mD5Script;
    public UserDbTest userDbTest;

    public TMP_InputField userInputField;
    public TMP_InputField passwordField;
    public TMP_Text errorMessage;

    public void CheckDataBase()
    {
        string username = userInputField.text;

        UserDb userDb = new UserDb();
        System.Data.IDataReader reader = userDb.getDataByString(username);

        if (reader != null)
        {
            if (reader.Read())
            {
                // Retrieve the hashed password stored in the database
                string hashedPasswordFromDb = reader[1].ToString();

                // Hash the password provided by the user 
                string hashedPasswordProvidedByUser = mD5Script.GenerateMD5Hash(); 

                // Compare the hashed passwords
                if (hashedPasswordFromDb.Equals(hashedPasswordProvidedByUser))
                {
                    // Passwords match, user authentication successful
                    Debug.Log("User authenticated successfully");
                    LoadInGM();
                }
                else
                {
                    // Passwords don't match, authentication failed
                    errorMessage.text = "Incorrect password";
                }
            }
            else
            {
                // User not found in the database
                errorMessage.text = "User does not exist";
            }
        }
    }

    public void LoadInGM()
    {
        SceneManager.LoadScene("Scene4 - Game Menu");
    }

}
