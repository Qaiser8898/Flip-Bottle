using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iojzvcjz : MonoBehaviour
{
    private Rigidbody rb;
    public float torque;
    int count;
    Vector3 currentEulerAngles;
    public float upward = 2f;
    public float stop = 8;
    public float forword;
    public bool moving = false;



    int countjump, maxjump;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        moving = false;

    }

    // Update is called once per frame
    void Update()
    {
            if (moving == false)
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
            else
            {
                Debug.Log("Eular angles : " + transform.localRotation.eulerAngles);
            if (transform.rotation.eulerAngles.z <= stop)
            {
                rb.angularVelocity = Vector3.zero;
                rb.velocity = Vector3.zero;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}
