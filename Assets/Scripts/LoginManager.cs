using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoginManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Joke j = ApiHelper.GetNewJoke();
       Debug.Log(j.value); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable(){
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button btnLogin = root.Q<Button>("btnLogin");
        TextField txtUsername = root.Q<TextField>("txtUsername");
        btnLogin.clicked += ()=> {
            txtUsername.value = ApiHelper.GetNewJoke().value;
        };
    
    }
}
