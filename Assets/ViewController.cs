using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{



    float H;
    float V;
    Vector3 moveVector;
    public Vector3 mousePos; //mouse position

    public float speed;
    public float turnSpeed;
    public float TurnTolerance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");

        mousePos = new Vector3(Screen.width / 2, Screen.height / 2, 0) - Input.mousePosition;

        moveVector = new Vector3(H, 0, V) * speed;
        transform.Translate(moveVector * Time.deltaTime);

        Debug.DrawLine(transform.position, transform.forward * 100, Color.red);
        
        if(mousePos.x > TurnTolerance)
        {
            float screenPercentX = Mathf.Abs(mousePos.x / (Screen.width / 2));
            transform.Rotate(new Vector3(0, (-turnSpeed * screenPercentX) * Time.deltaTime, 0), Space.World);
        }else if( mousePos.x < TurnTolerance)
        {
            float screenPercentX = Mathf.Abs(mousePos.x / (Screen.width / 2));
            transform.Rotate(new Vector3(0, (turnSpeed * screenPercentX) * Time.deltaTime, 0), Space.World);
        }


    }
}
