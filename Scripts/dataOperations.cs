using Firebase;
using Firebase.Unity;
using Firebase.Database;
using Firebase.Extensions; // for ContinueWithOnMainThread
using System;
using System.Collections.Generic;
using UnityEngine;


namespace datBaseOpers
{
    public class dataOperations : MonoBehaviour
    {
        private string str;
        private DatabaseReference dbref;
        private void Start()
        {
            dbref = FirebaseDatabase.DefaultInstance.RootReference;
           // User user = new User("Mitya", "g7IBOIzYcxefYlvnXYQrgmlXXr03", "@gmail", 6000);
           //CreateNewAccData(user);
            //User user = new User ("Mitya",  GetData("Users","g7IBOIzYcxefYlvnXYQrgmlXXr03"), GetData("Users", "g7IBOIzYcxefYlvnXYQrgmlXXr03", "Email"), 6000);
            
            Debug.Log("fff");
        }
       
        public void Update()
        {
            
        }
        /// <summary>
        /// Return data snapshot from child
        /// </summary>
        /// <param name="Child_1"></param>
        public string GetData(string Child_1)
        {

            dbref.Child(Child_1).GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("data corrupted");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;

                    str = Convert.ToString(snapshot.GetValue(true));

                }
            });
            return str;
        }
        public string GetData(string Child_1,string Child_2,string Child_3)
        {

            dbref.Child(Child_1).Child(Child_2).Child(Child_3).GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("data corrupted");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;

                    str = Convert.ToString(snapshot.GetValue(true));

                }
            });
            return str;
        }
        /// <summary>
        /// Return data snapshot from child's
        /// </summary>
        /// <param name="Child_1"></param>
        public string GetData(string Child_1, string Child_2)
        {

            dbref.Child(Child_1).Child(Child_2).GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("data corrupted");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    
                    str = Convert.ToString(snapshot.GetValue(true));
                    
                }
            });
            return str;
        }

        public void CreateNewAccData(User user)
        {
            string json = JsonUtility.ToJson(user);
            dbref.Child("Users").Child(user.UID).SetRawJsonValueAsync(json);
        }
        
    }
}
