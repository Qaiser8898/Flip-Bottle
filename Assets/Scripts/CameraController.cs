using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform player;
    //Public variable to store a reference to the player game object

    private Vector3 offset;          //Private variable to store the offset distance between the player and camera
    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
        offset.y = 0; // set the y offset to zero
        offset.z = 0; // set the z offset to zero
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 target = new Vector3(player.position.x, transform.position.y, transform.position.z) + offset;
        transform.position = target;
    }
}