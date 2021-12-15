using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class CarController : MonoBehaviour
{   
    public TextMeshProUGUI countText;
    public TextMeshProUGUI countFinal;
    public GameObject gameCompleteUI;
    private int count;
    private int count1;
    public TextMeshProUGUI timerText;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;
    string logDir;
    private void start()
    {
        
       /* GameObject lightGameObject = new GameObject("The Light");
        Light lightComp = lightGameObject.AddComponent<Light>();*/
        count = 0;
        count1 = 0;
        /*yo = GameObject.FindGameObjectsWithTag("Test");*/
        SetcountText();
        SaveData();
    }
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();       
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            count = count + 1;
            SetcountText();
            
            /*yo.light.enabled = false;*/
            /* lightComp.color = Color.blue;*/
        }

        if (other.gameObject.CompareTag("Finish")){
            gameCompleteUI.SetActive(true);
            Debug.Log("Finish");
            count1 = count;
            setCountFinal();
            SaveData();
            Time.timeScale=0;
            
        }
        /*if (other.gameObject.CompareTag("Test"))
        {
            other.gameObject.SetActive(false);
        }*/

    }

    void SetcountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void setCountFinal()
    {
        countFinal.text = "Count: " + count1.ToString();
    }
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
