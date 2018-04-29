using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using LD41;

public class PlayerMovement : SingletonBehaviour<PlayerMovement> {

	#region Variables
	//public
	public GameObject scoreText;
    public Camera cam;
	public Vector3 gravity;
	public float maxAngle = 30;
    public Animator animator;
    public float life = 1.1f;

	//private
	[SerializeField]
	private float movementSpeed = 0.0f;
	private Rigidbody myRB;
	private UIFunctions uiFunctions;

	private Vector3 lastPos;
	private Vector3 vel;
    private bool moving;
    private bool died = false;

	#endregion

	#region UnityFunctions

	void Start () 
	{
		myRB = GetComponent<Rigidbody> ();
		uiFunctions = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<UIFunctions> ();
		//Physics.gravity = gravity;

		lastPos = transform.position;
		vel = Vector3.zero;
        moving = false;
	}

	void FixedUpdate () 
	{
        if (UIFunctions.Instance.gameStarted)
        {
            Move();
            UpdateHealth();
        }
		//float speed = ((transform.position - lastPos) / Time.deltaTime).y;
		//lastPos = transform.position;
		//vel = transform.up * speed;

	}

	#endregion 

	private void Move()
	{
        if (transform.position.x < -9.5f)
        {
            myRB.velocity = Vector3.zero;
            transform.position = new Vector3(-9.4f, transform.position.y, transform.position.z);
            myRB.AddForce(Vector3.right * 2);
            return;
        }
        else if (transform.position.x > 9.5f)
        {
            myRB.velocity = Vector3.zero;
            transform.position = new Vector3(9.4f, transform.position.y, transform.position.z);
            myRB.AddForce(Vector3.left * 2);
            return;
        }

        float hAxis = 0;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetMouseButton(0) || Input.touchCount == 1)
        {

            if (Input.GetAxis("Horizontal") != 0)
            {
                hAxis = Input.GetAxis("Horizontal");
            }
            else if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x < (Screen.width / 2))
                {
                    hAxis = -0.8f;
                }
                else if (Input.mousePosition.x > Screen.width / 2)
                {
                    hAxis = 0.8f;
                }
            }
            else if (Input.touchCount == 1)
            {
                Touch touch0 = Input.GetTouch(0);
                if (touch0.position.x < Screen.width / 2)
                {
                    hAxis = -0.8f;
                }
                else if (touch0.position.x > Screen.width / 2)
                {
                    hAxis = 0.8f;
                }
            }


            if (!moving)
                animator.Play("Walk");
            moving = true;


            Vector3 moveDir = new Vector3(hAxis, 0, 0);
            myRB.velocity = moveDir * movementSpeed * Time.fixedDeltaTime;

            if (hAxis < 0)
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }
        else
        {
            moving = false;
            myRB.velocity = myRB.velocity * 0.9f;
        }
	}

    private void UpdateHealth()
    {
        life -= Time.deltaTime * 0.01f;
        life = life < 0 ? 0 : life;

        PostProcessingManager.Instance.UpdateGray(life);

    }

    public void AddHealth(float amount = 0.01f)
    {
        if (died)
            return;
        
        life += amount;
        if (life > 1.2f)
            life = 1.2f;
    }

    public void LoseHealth()
    {
        life -= 0.1f;
        if (life < 0)
        {
            PlayDie();
            UIFunctions.Instance.gameStarted = false;    //Disable the game
            UIFunctions.Instance.GameEnded();
        }
    }

    public void PlayDie()
	{
        if (died)
            return;

        myRB.velocity = Vector3.zero;
        died = true;
        animator.Play("Die");
        transform.DOMoveY(-0.7f, 2).SetRelative();
	}
	/*
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Water") 
		{
			scoreText.SetActive (false);
			uiFunctions.gameStarted = false;    //Disable the game
			uiFunctions.GameEnded();
		}

		if (collision.gameObject.tag == "CtrlPlatform") {
			//myRB.velocity = Vector3.Reflect (myRB.velocity, collision.contacts [0].normal) * 2;
			//myRB.AddForce (myRB.velocity.normalized * 1000);



			Vector3 normal = collision.contacts[0].normal;
			Vector3 localVel = vel; // myRB.velocity;
			Vector3 targetVel = collision.gameObject.GetComponent<PlatformBalance> ().GetVel();
			//Debug.Log (targetVel);

			///Debug.Log(Vector3.Angle(localVel, normal));
			// measure angle
			if (Vector3.Angle(localVel, normal) < maxAngle){
				// bullet bounces off the surface
				Vector3 newVel = Vector3.Reflect(localVel, normal);
				//Debug.Log(Vector3.Dot(targetVel, newVel));
				//myRB.velocity = newVel * (Vector3.Dot (targetVel, newVel));
			} else {
			}
		}
	}
	*/
}
