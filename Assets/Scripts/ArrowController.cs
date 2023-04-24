using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.rotation.eulerAngles.y >= 60){
                transform.Rotate(Vector3.down, Time.deltaTime * 30f);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.rotation.eulerAngles.y <= 120){
                transform.Rotate(Vector3.up, Time.deltaTime * 30f);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.localScale.x < 0.7f)
            {
                transform.localScale = new Vector3(transform.localScale.x + (1 * Time.deltaTime), transform.localScale.y,
                    transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(0.7f, transform.localScale.y, transform.localScale.z);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.localScale.x > 0.1f)
            {
                transform.localScale = new Vector3(transform.localScale.x - (1 * Time.deltaTime), transform.localScale.y,
                    transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(0.1f, transform.localScale.y, transform.localScale.z);
            }

        }
    }
}
