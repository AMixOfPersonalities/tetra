using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterUI : MonoBehaviour
{
    // Reference to the MD5Script component
    public MD5Script md5Script;
    public UserDbTest userDbTest;

    public TMP_InputField userInputField;
    public TMP_InputField passwordField;
    public TMP_InputField emailInputField;


    public void RegisterButton()
    {
        // Get inputs from user
        string username = userInputField.text;
        string password = md5Script.GenerateMD5Hash(); // Hash the password
        string email = emailInputField.text;

        // Add entry to user database
        userDbTest.AddEntryUserDb(username, password, email);

        // Read all entries from the user database
        userDbTest.ReadUserDb();
    }
}