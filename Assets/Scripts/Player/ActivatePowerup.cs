using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerup : MonoBehaviour
{
    public GameObject powerUpRing;
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
            ActivateRing();
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerUpRing.SetActive(false);
    }
}
