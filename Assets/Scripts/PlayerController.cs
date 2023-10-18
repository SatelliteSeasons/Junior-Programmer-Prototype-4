using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float powerRejection = 30;

    private Rigidbody playerRb;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndication;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float inputVertical = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * inputVertical);
        powerupIndication.transform.position = this.transform.position + new Vector3(0, -0.1f, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup") ) //other est un collider qui possède CompareTag, ok
        {
            Destroy(other.gameObject);
            this.hasPowerup = true;
            powerupIndication.SetActive(true);
            StartCoroutine(PowerupCountdown());
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndication.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("TU viens de percuter : " + collision.gameObject.name + " avec le powerup : " + hasPowerup);

            Rigidbody ennemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position).normalized;

            ennemyRb.AddForce(awayFromPlayer * powerRejection, ForceMode.Impulse);
        }
    }

    //Because the first is (Collider other) and the second is (Collision collision)

    //so the first uses Collider while the second uses Collision

    //according to another forum

    //"collision has the information about the impact, such as velocity and points of impact.

    //Colliders are the objects that made the impact."

    //so if i understood it correctly we didn't need to specify gameobject on Collider because it's already the gameobject. 
}
