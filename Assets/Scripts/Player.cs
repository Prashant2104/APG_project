using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Walk = 3f;
    public float Run = 7f;
    public float smoothmoveTime = 0.1f;
    public float turnspeed = 8f;

    float speed;
    float angle;
    float smoothinputMagnitude;
    float smoothmoveVelocity;
    Vector3 Velocity;
    private Animator anim;
    private Rigidbody rigidbody = new Rigidbody();
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical")));
        //transform.Translate(translation: InputDirection * speed * Time.deltaTime);
        //transform.Translate(inputDirection * speed * Time.deltaTime);

        Vector3 InputDirection = new Vector3(x: Input.GetAxisRaw("Horizontal"), y: 0, z: Input.GetAxisRaw("Vertical")).normalized;        
        float InputMagnitude = InputDirection.magnitude;
        smoothinputMagnitude = Mathf.SmoothDamp(smoothinputMagnitude, InputMagnitude, ref smoothmoveVelocity, smoothmoveTime);
        float targetAngle = Mathf.Atan2(InputDirection.x, InputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnspeed * InputMagnitude);
        Velocity = transform.forward * speed * smoothinputMagnitude;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Jump", false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("Attack",true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("Attack", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = Run;
            anim.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = Walk;
            anim.SetBool("Run", false);
        }
        if(Input.GetKey(KeyCode.Space) && speed >= 0.01)
        {
            anim.SetBool("Run_Jump", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Run_Jump", false);
        }
        anim.SetFloat("Speed", smoothinputMagnitude);

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        rigidbody.MovePosition(rigidbody.position + Velocity * Time.deltaTime);
    }
}