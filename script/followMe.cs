using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMe : MonoBehaviour
{
    public GameObject target;
    public Vector2 camPosMin , camPosMax;
    [Range(0, .3f)] [SerializeField] public float smoothTime;
    private Vector2 velocity;
    float posY;
    float posX;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        posY = Mathf.SmoothDamp(
            transform.position.y,
            target.transform.position.y, 
            ref velocity.y, 
            smoothTime);
        posX = Mathf.SmoothDamp(
            transform.position.x,
            target.transform.position.x,
            ref velocity.x,
            smoothTime);


    }
    void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(posX, camPosMin.x, camPosMax.x),
            Mathf.Clamp(posY, camPosMin.y, camPosMax.y), 
            transform.position.z);
    }
}
