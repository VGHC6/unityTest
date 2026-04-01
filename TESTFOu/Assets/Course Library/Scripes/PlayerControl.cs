using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject focalPoint;
    public float speed=10f;
    public float powerUpStrength=15f;
    public bool isPowerOn=false;

    public GameObject RingSign;

    public float waitTime=7;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();

        focalPoint=GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float ForwordInput= Input.GetAxis("Vertical");

        rb.AddForce(focalPoint.transform.forward*ForwordInput*speed);

        RingSign.SetActive(isPowerOn);
        if (isPowerOn)
        {
            RingSign.transform.position=transform.position+new Vector3(0,0.5f,0);

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerLight"))
        {
            isPowerOn = true;
            Destroy(other.gameObject);

            StartCoroutine(PowerUpCountDown());//调用携程
        }
    }

    IEnumerator PowerUpCountDown()//携程
    {
        yield return new WaitForSeconds(waitTime);
        isPowerOn = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy")&& isPowerOn){
            Rigidbody enemeyRB=collision.gameObject.GetComponent<Rigidbody>();

            Vector3 dirFromPlayer=collision.transform.position-transform.position;

            enemeyRB.AddForce(dirFromPlayer*powerUpStrength,ForceMode.Impulse);
        }
    }
}
