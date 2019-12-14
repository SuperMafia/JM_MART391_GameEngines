using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBoxScript : MonoBehaviour
{
    [SerializeField]
    int health = 1;

    [SerializeField]
    Object destructableRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            health--;
            if(health <= 0)
            {
                ExplodeThisGameObject();
            }
        }
    }

    void ExplodeThisGameObject()
    {
        GameObject destructable = (GameObject)Instantiate(destructableRef);
        //map the newly loaded destructable object to the x/y coordinates of the destroyed object
        destructable.transform.position = transform.position;
        Destroy(gameObject);
    }
}