using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pin : MonoBehaviour
{
    public bool isStanding = true;

    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Ball") || other.collider.CompareTag("Pin")){

            if (isStanding){
                isStanding = false;
                GameObject.FindGameObjectWithTag("Ball").GetComponent<BowlingBall>().points++;
            }
        }
    }

}
