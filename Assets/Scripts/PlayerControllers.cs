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
    private LevelManager lm;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        isGrounded = true;
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
    int prdir = -1;
    void Move()
    {

        Vector3 euler = new Vector3(0, 0, 0);
        Vector3 vec = Vector3.zero;
        if (getAction("left"))
        {
            vec = Vector3.back;
            dir = 0;
            euler.y = -180;
        }
        else if (getAction("right"))
        {
            vec = Vector3.forward;
            dir = 1;
            euler.y = 0;
        }
        else
            dir = -1;


        if (dir != -1)
        {
            if (dir == 0)
            {
                euler.y = -180;
            }
            else
            {
                euler.y = 0;
            }
            //if (dir != prdir) transform.Rotate(0, dir == 1 ? -180 : 180, 0);
            rb.AddForce(vec * speed);
        }
        else if (prdir != dir)
        {
            rb.AddForce(-(vec * speed));

		}
            transform.eulerAngles = euler;

        prdir = dir;
	}
    // Update is called once per frame
    void Update()
    {
        Move();

        if (getAction("up"))
        {
			int stuff = ~GameManager.instance.gameData;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
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
		if (collision.gameObject.tag == "coin")
		{
            Destroy(collision.gameObject);
            GameManager.instance.gameData.totalCoins++;
            lm.UpdateCoinsText();
            lm.ActivateGameOver();
		}
	}
}