using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MaxAcceleration;
    public float MaxSpeed;
    private Vector3 input;
    private Vector3 velocity;
    private Vector3 acceleration;
    private Vector3 moveAmount;
    private Rigidbody rigid;
    private Vector3 deceleration;
    public float decelAmt;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        decelAmt = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();   
    }

    void Movement()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        acceleration = input.normalized * MaxAcceleration;
        velocity += acceleration;
        print(velocity);

        deceleration = -1*velocity*decelAmt;
        print("decel " + deceleration);
        velocity += deceleration;
        print(velocity + " 2");

        VectorCap(ref velocity, MaxSpeed);
        moveAmount = velocity * Time.deltaTime;
        rigid.transform.Translate(moveAmount);
        //s = ut + 1/2at^2
    }

    //caps vector at length s
    void VectorCap(ref Vector3 v, float s)
    {
        if (v.magnitude > s)
        {
            v = v.normalized * s;
        }
    }
}
