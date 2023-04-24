using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BowlingBall : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float speed = 40f;

    private int throwNumber = 0;

    private Transform arrow;
    private Transform startPosition;

    private bool isMoving;

    private List<GameObject> pins = new List<GameObject>();
    public Pin[] pinsArray { get; private set; }

    private readonly Dictionary<GameObject, Transform> pinsTransform = new();

    public int points = 0;

    private void Start()
    {
        Application.targetFrameRate = 60;
        arrow = GameObject.FindGameObjectWithTag("Arrow").transform;

        startPosition = transform;
        this.pinsArray = GameObject.FindObjectsOfType<Pin>();
        for (int i = 0; i < pinsArray.Length; i++)
        {
            pinsTransform.Add(pinsArray[i].gameObject, pinsArray[i].gameObject.transform);
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwNumber += 1;
            StartCoroutine(ThrowBall());
        }
    }

    private IEnumerator ThrowBall()
    {
        isMoving = true;
        arrow.gameObject.SetActive(false);
        rigidBody.isKinematic = false;

        Vector3 forceVector = -1 * arrow.right * (speed * arrow.localScale.x);
        Vector3 forcePosition = transform.position + (transform.forward * 0.5f);

        rigidBody.AddForceAtPosition(forceVector, forcePosition, ForceMode.Impulse);

        yield return new WaitForSecondsRealtime(10);

        isMoving = false;

        if (points == pinsArray.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (throwNumber == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            ResetBall();
        }
    }

    private void ResetBall()
    {
        transform.position = new Vector3(0f, 0.35f, -11.77f);
        transform.rotation = startPosition.rotation;
        rigidBody.isKinematic = true;
        rigidBody.velocity = Vector3.zero;
        arrow.gameObject.SetActive(true);
        for (int i = 0; i < pinsArray.Length; i++)
        {
            GameObject pin = pinsArray[i].gameObject;
            if (!pinsArray[i].isStanding)
            {
                pin.SetActive(false);
            }
            pin.transform.position = pinsTransform[pin].position;
            pin.transform.rotation = pinsTransform[pin].rotation;
        }
    }
}
