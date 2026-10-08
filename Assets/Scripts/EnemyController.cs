using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private bool tonto;
    [SerializeField] private float moveSpeed;

    private bool playerDetected = false;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerDetected = true;
        }

        if (other.gameObject.tag == "limiteEnemigo" || tonto == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }
    void onCollisionEnter(Collision collision)
    {
        transform.eulerAngles += new Vector3(0, 180, 0);
	}
}
