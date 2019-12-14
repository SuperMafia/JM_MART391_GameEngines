using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleRigidBody : MonoBehaviour
{
    [SerializeField]
    Vector2 forceDir;

    [SerializeField]
    float torque;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        float randTorque = UnityEngine.Random.Range(-250, 250);
        float randForceX = UnityEngine.Random.Range(forceDir.x - 250, forceDir.x + 250);
        float randForceY = UnityEngine.Random.Range(forceDir.y, forceDir.y + 350);

        forceDir.x = randForceX;
        forceDir.y = randForceY;

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(forceDir);
        rb2d.AddTorque(randTorque);
    }

}
