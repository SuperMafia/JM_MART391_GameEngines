using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    // Used to reference player of build
    [SerializeField]
    GameObject player;

    // Used for smoother camera transitions
    [SerializeField]
    float timeOffset;

    // Used to bridge between camera position and player position
    [SerializeField]
    Vector2 posOffset;

    // These limits are used for the Mathf.Clamp function for the camera
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;

    // Used as a component of SmoothDamp instructions
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera's start position
        Vector3 startPos = transform.position;

        //Player's current position
        Vector3 endPos = player.transform.position;

        //Offset positions used to transition camera from startPos to endPos
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        // *L*inear Int*erp*olation Version, uses deltaTime
        // transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        // In-built Unity API code; utilizes a Velocity as well as a timeOffset, deltaTime is unnecessary due to velocity
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        // Clamp is used to establish limit to the camera's position going left, right, bottomside, or topside
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z);
    }

    void OnDrawGizmos()
    {
        //Draw a box based on camera boundaries
        Gizmos.color = Color.red;
        //topside boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        //right boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        //bottomside boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        //left boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }
}
