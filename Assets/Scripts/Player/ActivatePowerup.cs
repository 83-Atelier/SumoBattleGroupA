using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerup : MonoBehaviour
{
    public GameObject powerUpRing;
    private bool hasPowerup = false;
    private float powerupStrength = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RingPosition();
    }

    public void ActivateRing()
    {
        powerUpRing.SetActive(true);

    }
    public void DeactivateRing()
    {
        powerUpRing.SetActive(false);
    }

    private void RingPosition()
    {
        powerUpRing.transform.position = transform.position - new Vector3(0, 0.5f, 0);
        powerUpRing.transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            ActivateRing();
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    // check if the powerup is active and player and enemy have collided, knockback enemy if true
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.transform.position - transform.position;

            Debug.Log("Player collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerUpRing.SetActive(false);
        hasPowerup = false;
    }
}
