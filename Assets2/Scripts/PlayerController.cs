using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Vector3 v3Force;
   
    public  Rigidbody rB;
    [SerializeField]
     KeyCode keyPositive;
    public float speed;
    public bool ballIsOnTheGround = true;
    private bool wallPower = false;

    private void Start()
    {
        rB = GetComponent<Rigidbody>();
        StartCoroutine(CalcSpeed());
    }
  
  
    IEnumerator CalcSpeed()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            Vector3 prevPos = transform.position;
            yield return new WaitForFixedUpdate();
            speed = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime);

        }
    }
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.UpArrow) && ((Input.GetKey(KeyCode.LeftShift)  || (Input.GetKey(KeyCode.RightShift) )))) && speed <= 705)
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0f, 0f, 0.65f);


        }
        else if (Input.GetKey(keyPositive)  && (speed <= 220f))
        { 
            GetComponent<Rigidbody>().velocity += v3Force;
            }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().velocity -= new Vector3(0f, 0f, 0.6f);
         
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0.43f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(-0.43f, 0f, 0f);
        }

     
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ballIsOnTheGround)
        {
            rB.AddForce(new Vector3(0f, 50f, 0f), ForceMode.Impulse);
            ballIsOnTheGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && wallPower)
        {
            rB.AddForce(new Vector3(0f, 50f, 100f), ForceMode.Impulse);
            wallPower = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ballIsOnTheGround = true;

        }
        if (collision.gameObject.tag == "Wall")
        {
            wallPower = true;

        }
        if (collision.gameObject.tag == "Ramp")
        {
            rB.AddForce(new Vector3(0f, 90f, 130f), ForceMode.Impulse);
        }
    }
    
}
