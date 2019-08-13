using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickMove : MonoBehaviour
{
    
    float speed = 6f;
    Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("1"); 
            targetPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target.position = targetPos;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        
    }
}
