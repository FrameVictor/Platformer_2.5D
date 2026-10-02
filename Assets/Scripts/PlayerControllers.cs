using System.Collections;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private bool isGrounded = true;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
	}

    bool getAction(string action)
    {
        switch (action)
        {
            case "left": return Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
            case "right": return Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
            case "up": return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
			case "down": return Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
			default: return false;
		}
    }
    int dir = -1;
    void Move()
    {
        Vector3 vec = new Vector3();
        var prdir = dir;
        if (getAction("left"))
        {
            vec = Vector3.back;
            dir = 0;
        }
        else if (getAction("right"))
        {
            vec = Vector3.forward;
            dir = 1;
        }
        else
            dir = -1;
        if (dir != -1)
        {
		    transform.Translate(Vector3.back * speed * Time.deltaTime);
            if (dir != prdir) transform.Rotate(0, dir == 0 ? -180 : 180, 0);
        }
        print(dir);

        prdir = dir;
	}
    // Update is called once per frame
    void Update()
    {
        Move();

        if (getAction("up"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
            Debug.Log("Stay");
        }

        if (collision.gameObject.tag == "tocho")
        {
        }
    }
}
