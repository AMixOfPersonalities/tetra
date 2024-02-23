using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RegistrationManager : MonoBehaviour
{
    public TMP_InputField userInputField;
    public TMP_InputField passwordField;
    public TMP_InputField confirmPassField;
    public TMP_InputField emailInputField;
    public TMP_Text validationText;
    public TMP_Text Password;
    public TMP_Text confirmPassword;

    public Button RegisterButton;

    private bool EmailValid = false;
    private bool UserValid = false;
    private bool PassValid = false;
    private bool ConfirmPassValid = false;

    private void Start()
    {
        RegisterButton.interactable = false;
        // Subscribe to the OnValueChanged event of the input field
        emailInputField.onValueChanged.AddListener(ValidateEmail);
        userInputField.onValueChanged.AddListener(ValidateUsername);
        passwordField.onValueChanged.AddListener(ValidatePassword);
        confirmPassField.onValueChanged.AddListener(ValidateConfirmPass);
    }

    private void Update()
    {
        if (EmailValid && UserValid && PassValid && ConfirmPassValid)
        {
            Debug.Log("all fields valid");
            RegisterButton.interactable = true;
        }
    }

    private void KeepTagline(bool Valid)
    {
        validationText.text = "Looking Good!";
        validationText.color = Color.black;
    }

    private void ChangeTagline(string tagline)
    {
        validationText.text = tagline;
        validationText.color = Color.red;
    }

    private void ValidateInput(bool valid,string input,string pattern, string tagline)
    {
        bool isValid = Regex.IsMatch(input, pattern);
        if (isValid)
        {
            KeepTagline(valid);
            valid = true;
        }
        else
        {
            ChangeTagline(tagline);
        }
    }

    private void ValidateEmail(string input)
    {
        // Regular expression pattern for a valid email address
        // regex created from rules in https://en.wikipedia.org/wiki/Email_address#Local-part
        // Matches characters not in the set: <>()[]\.,;:\s@"
        // Followed by zero or more groups of dot and characters not in the set
        // OR matches a quoted string
        // Matches the @ symbol
        // IP address in square brackets
        // Matches one or more groups of characters, digits, or hyphen followed by a dot
        // Followed by at least two alphabetic characters
        string pattern = @"^(([^<>()\[\]\\.,;:\s@\""]+(\.[^<>()\[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
        ValidateInput(EmailValid ,input, pattern, "Invalid Email");

    }

    private void ValidateUsername (string input)
    {
        string pattern = @"^[a-z0-9_\-()]{3,20}$";
        ValidateInput(UserValid,input, pattern, "Username must only contain 3-20 alphanumeric characters or '_-()'");
    }

    private void ValidatePassword(string input)
    {
        string pattern = @"^[a-zA-Z0-9_\-()!@#$%^&*]{8,20}$"; // Example pattern for a more secure password
        ValidateInput(PassValid, input, pattern, "Password must be 8-20 characters long and can contain alphanumeric characters or '_-()!@#$%^&*'");
    }
    private void ValidateConfirmPass (string input)
    {
        if (passwordField.text != confirmPassField.text)
        {
            ChangeTagline("Passwords must match");
            ConfirmPassValid = true;
        }
        else
        {
            KeepTagline(ConfirmPassValid);
            RegisterButton.interactable = true;
        }
    }

}
