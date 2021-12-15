using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class get_login : MonoBehaviour
{

    public TMP_InputField login;
    public TMP_InputField password;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("login", login.text);
        PlayerPrefs.SetString("password", password.text);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString("login", login.text);
        PlayerPrefs.SetString("password", password.text);
    }
}
