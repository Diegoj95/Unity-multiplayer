using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;


public class PlayerScript : NetworkBehaviour
{
    [SerializeField] float speed=3;
    float h, v;
    Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    [Client(RequireOwnership = true)]

    void Move(){
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        moveDirection.x = h;
        moveDirection.y = v;
        

        transform.position += moveDirection * Time.deltaTime * speed;
    }

}
