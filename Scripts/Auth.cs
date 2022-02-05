using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
public class Auth : MonoBehaviour
{
    public Text Email;
    public Text Password;
    string email;
    string password;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void enterEmail()
    {
        email = Email.text;
    }
    public void enterPassword()
    {
        password = Password.text;
    }
    public void buttonRegist()
    {
        registNew();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void registNew()
    {
        FirebaseAuth auth;
        auth = FirebaseAuth.DefaultInstance;
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }
}
