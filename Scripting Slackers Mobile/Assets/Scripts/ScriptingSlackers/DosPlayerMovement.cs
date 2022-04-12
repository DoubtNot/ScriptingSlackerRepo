using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class DosPlayerMovement : MonoBehaviour
{


	private Rigidbody2D rigid;
	public float speed;
	public float jump;
	public bool isGrounded;
	public float health;
	public Slider healthBar;
	public Slider healthBar1;
	public float maxHealth = 10f;
	public AudioClip hitSound;
	public AudioClip finishSound;
	public GameObject pauseButton, pausePanel;

	[SerializeField] string[] scenes;

	float horizontal;

	void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
		health = maxHealth;
		healthBar.value = health;
		healthBar1.value = health;
		pausePanel.SetActive(false);
		pauseButton.SetActive(true);
	}


	void FixedUpdate()
	{
		//this is checking for key pushes to move. needs to be changed to the left and right ui buttons in the canvas

		if (Input.GetAxis("Horizontal") != 0)
		{
			HorizontalMovement(Input.GetAxis("Horizontal"));
		}
		if (horizontal != 0)
		{
			HorizontalMovement(horizontal);
		}


		if (Input.GetButtonDown("Jump")) //this needs to be changed from "jump" to the ui button in the canvas
		{
			Jump();
		}

		if (health <= 0)
		{
			LoadRandomLevel();
		}

	}

	public void SetHorizontal(float value)
	{
		horizontal = value;
	}
	private void HorizontalMovement(float value)
	{
		rigid.AddForce(new Vector2(value * speed, 0), ForceMode2D.Force);
	}

	public void Jump()
	{
		if (Time.timeScale != 0)
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, 9);
			if (hit.collider != null && hit.collider.tag == "Ground")
			{
				isGrounded = true;
			}
			else
			{
				isGrounded = false;
			}

			if (isGrounded)
			{
				rigid.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
			}
		}
	}

	public void LoadRandomLevel()
	{
		if (scenes.Length > 0)
		{
			int index = UnityEngine.Random.Range(0, scenes.Length);
			SceneManager.LoadScene(scenes[index]);
		}
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Ground")
		{

			isGrounded = true;

		}


		if (collision.transform.tag == "Spike")
		{
			health -= 2;
			healthBar.value = health;
			healthBar1.value = health;
			AudioSource.PlayClipAtPoint(hitSound, collision.transform.position);
		}

		if (collision.transform.tag == "Alien")
		{
			health -= 1;
			healthBar.value = health;
			healthBar1.value = health;
			AudioSource.PlayClipAtPoint(hitSound, collision.transform.position);
		}

		if (collision.transform.tag == "Fire")
		{
			health -= 50;
			healthBar.value = health;
			healthBar1.value = health;
			AudioSource.PlayClipAtPoint(hitSound, collision.transform.position);
		}

		if (collision.transform.tag == "FinishLine") //the "finishline" is being used for the blupee collect sound
		{
			AudioSource.PlayClipAtPoint(finishSound, collision.transform.position);
		}



	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.transform.tag == "Ground")
		{
			isGrounded = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.transform.tag == "Blupee")
		{
			health += 2;
			healthBar.value = health;
			healthBar1.value = health;
			AudioSource.PlayClipAtPoint(finishSound, collider.transform.position);
			Destroy(collider.gameObject);
		}

		if (collider.transform.tag == "Secret Blupee")
		{
			health += 40;
			healthBar.value = health;
			healthBar1.value = health;
			Destroy(collider.gameObject);
		}
	}


	public void OnPause()
	{
		pausePanel.SetActive(true);
		Time.timeScale = 0;
	}

	public void OnUnPause()
	{
		pausePanel.SetActive(false);
		Time.timeScale = 1;
	}




}

