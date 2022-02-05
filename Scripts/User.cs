using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public string Name;
    public string Email;
    public int Balance;
    public string UID;
    public string Complaints;
    public User(string Name, string UID, string Email, int Balance)
    {
        this.Name = Name;
        this.UID = UID;
        this.Email = Email;
        this.Balance = Balance;
    }
}
