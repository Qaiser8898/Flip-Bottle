using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float torque;
    int count;
    Vector3 currentEulerAngles;
    public float upward = 2f;
    public float stop = 5;
    public float forword;
    public bool moving = false;
    public bool stopwin = false;
    public bool doublejump = false;
    public GameObject FailText;
    public GameObject WinText;
    public Text CountText;
    public GameObject Button;
    public GameObject ButtonLevel2;

    int countjump,maxjump;
    // Start is called before the first frame update
    void Start()
    {
        countjump = 0;
        maxjump = 2;
        count = 0;
        rb = GetComponent<Rigidbody>();
        moving = false;
        WinText.SetActive(false);
        FailText.SetActive(false);
        stopwin = false;
        Button.SetActive(false);
        ButtonLevel2.SetActive(false);
    }

    // Update is called once per frame
     void Update()
     {
        if (stopwin == false)
        {
            if (countjump<maxjump)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    countjump = countjump + 1;
                    Debug.Log("1st Jump");
                    moving = true;
                    Debug.Log("Eular before : " + transform.localRotation.eulerAngles);
                    rb.AddForce(forword, upward, 0, ForceMode.Impulse);
                    Debug.Log(gameObject.name);
                    // float turn = Input.GetAxis("Horizontal");
                    rb.AddTorque(0, 0, torque);
                }
            }
            if (moving == true)
            {
                StopRotating();
                Debug.Log("Eular angles : " + transform.localRotation.eulerAngles);
            }
        }
     }
   
    void StopRotating()
     {
        if (transform.rotation.eulerAngles.z <=stop)
        {
            rb.angularVelocity = Vector3.zero;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            Destroy(other.gameObject);
            Debug.Log("Coin destory"+ Time.time);
            Debug.Log("ANVelocity after coin collision:" + rb.angularVelocity);
            Debug.Log("Velocity after coin collision:" + rb.velocity);
            count = count + 1;
            SetText();
            Debug.Log("Count :" + count);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        countjump = 0;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        Debug.Log("Name: " + gameObject.name);
        moving = false;
        if (other.gameObject.name == "SmallTables")
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            WinText.SetActive(true);
            Button.SetActive(true);
            stopwin = true;
            ButtonLevel2.SetActive(true);
          }
        else if (other.gameObject.name == "Plane")
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            FailText.SetActive(true);
            Button.SetActive(true);
            stopwin = true;
        }
    }
   public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void SetText()
    {
        CountText.text = "Count:" + count.ToString();
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

}
