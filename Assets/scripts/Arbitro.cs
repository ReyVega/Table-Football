using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arbitro : MonoBehaviour
{
    public int rot = 5;

    public int rojoScr = 0;
    public Text rojoScrText;
    public int azulScr = 0;
    public Text azulScrText;


    public GameObject ball;


    // Start is called before the first frame update
    void Start()
    {

        Vector3 tmp = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
        while (tmp.x < 2.0f && tmp.x > -2.0f || tmp.z < 2.0f && tmp.z > -2.0f)
        {
            tmp = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
        }
        //ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
        ball.GetComponent<Rigidbody>().velocity = tmp;
        ball.GetComponent<Rigidbody>().transform.localPosition = new Vector3(0, 5.0f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (ball.GetComponent<Rigidbody>().velocity == new Vector3(0f, 0f, 0f))
        {
            Vector3 tmp = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
            while (tmp.x < 2.0f && tmp.x > -2.0f || tmp.z < 2.0f && tmp.z > -2.0f)
            {
                tmp = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
            }
            //ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
            ball.GetComponent<Rigidbody>().velocity = tmp;
            ball.GetComponent<Rigidbody>().transform.localPosition = new Vector3(0, 5.0f, 0);
        }
        if (ball.GetComponent<Transform>().localPosition.y < 0)
        {
            Vector3 tmp = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
            while (tmp.x < 2.0f && tmp.x > -2.0f || tmp.z < 2.0f && tmp.z > -2.0f)
            {
                tmp = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
            }
            // ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
            ball.GetComponent<Rigidbody>().velocity = tmp;
            ball.GetComponent<Rigidbody>().transform.localPosition = new Vector3(0, 5.0f, 0);
        }
    }

    void OnTriggerEnter(Collider ball) //mete gol → agregar if sacado con la x en cual portería chocó
    {
        if (ball.GetComponent<Transform>().localPosition.x < -14.0f)
        {
            rojoScr++;
            this.rojoScrText.text = "" + rojoScr;

        }
        else if (ball.GetComponent<Transform>().localPosition.x > 14.0f)
        {
            azulScr++;
            this.azulScrText.text = "" + azulScr;
        }
        else
        {
            Debug.Log("no gols");
        }
        Debug.Log("Gol en: " + ball.GetComponent<Transform>().localPosition.x);
        if (ball.gameObject.tag == "Pelota")
        {
            Vector3 tmp = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
            while (tmp.x < 2.0f && tmp.x > -2.0f || tmp.z < 2.0f && tmp.z > -2.0f)
            {
                tmp = new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f));
            }
            //ball.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-10.0f,10.0f),0f, Random.Range(-10.0f,10.0f));
            ball.gameObject.GetComponent<Rigidbody>().velocity = tmp;
            ball.gameObject.GetComponent<Rigidbody>().transform.localPosition = new Vector3(0, 5.0f, 0);
        }
    }
}
