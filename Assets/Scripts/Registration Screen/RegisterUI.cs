using UnityEngine;

public class RegisterUI : MonoBehaviour
{
    // Reference to the MD5Script component
    public MD5Script md5Script;

    public void RegisterButton()
    {
        // Check if the reference is assigned
        if (md5Script != null)
        {
            // Call the GenerateMD5Hash method on the md5Script instance
            string md5Result = md5Script.GenerateMD5Hash();

            // Check if the result is not null before logging
            if (md5Result != null)
            {
                Debug.Log("MD5 Hash Result: " + md5Result);
            }
        }
        else
        {
            Debug.LogError("MD5Script reference is not assigned!");
        }
    }
}