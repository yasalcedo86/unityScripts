using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float velocity;
    public bool right ;
    public LayerMask queEsPared;
    public float distance;
    public Transform rayDetection;
    public Vector2 rayDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * velocity * Time.fixedDeltaTime);
        RaycastHit2D ray = Physics2D.Raycast(rayDetection.position, rayDirection, distance);
        if (ray.collider != null)
        {
            if (ray.collider.tag == "muro")
            {
                if (right)
                {
                    transform.eulerAngles = new Vector3(0,-180,0);
                    right = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    right = true;
                }
                Debug.Log(ray.collider.tag);
            }
        }
       
    }
}
