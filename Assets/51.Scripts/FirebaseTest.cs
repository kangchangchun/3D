using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Proyecto26;
using UnityEngine.UI;


public class User
{
    public string name = string.Empty;
    public int score = 0;

    public User(string _name, int _score)
    {
        this.name = _name;
        this.score = _score;
    }

}


public class FirebaseTest : MonoBehaviour
{
    public const string myDBAddress = "https://kccpro1-b85e2.firebaseio.com/";
    public const string jsonExtension = ".json";

    public Text textName;
    public Text textScore;
    public InputField inputFieldName;
    public InputField inputFieldScore;

    private User user = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PostToDatabase()
    {
        RestClient.Put(myDBAddress + inputFieldName.text + jsonExtension, this.user); ;
    }
    private void ReceiveFromDatabase()
    {
        RestClient.Get<User>(myDBAddress + inputFieldName.text + jsonExtension).Then
            (response =>
               {
                   this.user = response;
               }
            );
    }


    public void OnCommit()
    {
        this.user = new User(inputFieldName.text, int.Parse(inputFieldScore.text));
        PostToDatabase();
    }
    public void OnReceive()
    {


        ReceiveFromDatabase();

        if (this.user != null)
        {
            textName.text = this.user.name;
            textScore.text = this.user.score.ToString();
        }
            
    }

}
