using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class save_data : MonoBehaviour
{
    public TMP_InputField login;
    public TMP_InputField password;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countText;
  
    string logDir;

    // Start is called before the first frame update
    void Start()
    {
        SaveData();
    }

    // Update is called once per frame
   /* void Update()
    {
         login.text = "To: " + ;
         password.text = "Number of falls: " + (ScoreScript.fallScore);
         timerText.text = "Number of Risky Decisions: " + ScoreScript.prevRiskyCount;
         countText.text =
         countFinal.text
    }*/
    private void SaveData()
    {
        logDir = "C:\\Users\\hp1\\OneDrive\\Desktop\\save.csv";
       
        if (File.Exists(logDir))
        {
            File.AppendAllText(logDir, System.Environment.NewLine + $"{timerText.text},{countText.text}");
        }
        else
        {
            File.WriteAllText(logDir, "login, password, time,count");
            File.AppendAllText(logDir, System.Environment.NewLine + $"{timerText.text},{countText.text}");
        }
    }
}
