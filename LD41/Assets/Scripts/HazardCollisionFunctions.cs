using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardCollisionFunctions : MonoBehaviour {

	#region Variables
	//public
	public GameObject restartButton;
	public GameObject homeButton;
	public GameObject scoreText;

	//private
	[SerializeField]
	private ParticleSystem hazardDustParticles;
	private Rigidbody myRB;

	#endregion

	#region UnityFunctions

	void Start () 
	{
		scoreText = GameObject.Find ("ScoreText");
		//restartButton = GameObject.Find ("RestartButton");
		//homeButton = GameObject.Find ("HomeButton");
		myRB = GetComponent<Rigidbody> ();
	}


    /*
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "MusicalNoteDeadZone") 
		{
            Debug.Log("Hit");
			Destroy (Instantiate (hazardDustParticles.gameObject, transform.position, Quaternion.identity), hazardDustParticles.startLifetime);
			this.gameObject.SetActive (false);
		}

		if (collision.gameObject.tag == "Player") 
		{
			scoreText.SetActive (false);
			//restartButton.SetActive (true);     //Enable the restart button
			//homeButton.SetActive (true);        //Enable the home button
            UIFunctions.Instance.gameStarted = false;    //Disable the game
            UIFunctions.Instance.GameEnded();
			//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			//Vector3 moveDir = new Vector3 (0, 10, 0);
			//myRB.velocity = moveDir * 50 * Time.fixedDeltaTime;
		}
	}
	*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MusicalNoteDeadZone")
        {
            Debug.Log("Hit");
            Destroy(Instantiate(hazardDustParticles.gameObject, transform.position, Quaternion.identity), hazardDustParticles.startLifetime);
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Player")
        {
            scoreText.SetActive(false);
            //restartButton.SetActive (true);     //Enable the restart button
            //homeButton.SetActive (true);        //Enable the home button
            UIFunctions.Instance.gameStarted = false;    //Disable the game
            UIFunctions.Instance.GameEnded();
            //SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
            //Vector3 moveDir = new Vector3 (0, 10, 0);
            //myRB.velocity = moveDir * 50 * Time.fixedDeltaTime;
        }
    }
	#endregion 
}
