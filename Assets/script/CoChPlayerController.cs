using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


//hey peter just wanted to let you know if youre reading this that I'm sorry
//I havent been the most attentive student but god knows I did try (sorta)
//youre a good teacher and I can tell you care, but I am having the hardest time trying to figure this out
//I know I shouldve come to you earlier, but I've just been busy I guess, no excuses
//anyways, I got like 3 main problems
//one, I want my player to turn just in the direction theyre going, not like a freaking air hockey puck
//two, what's up with the GameLoader thing? Can't figure that out, or the timer for that matter.
//three, I want my player to get off the screen when I win, so they don't keep hanging around when the win image pops up
//thanks, If you get back to me that would be cool I guess. but it is kinda late, so i give myself a b for effort :)



public class CoChPlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text endText;
	public Image customImage;
	public AudioSource meowSource;
	
	private Rigidbody2D rb2d;
	private int count;
	
	private float timer;
    private int wholetime;
	
	void Start()
	{
		meowSource = GetComponent<AudioSource> ();
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		customImage.enabled = false;
		SetCountText ();
		
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
		
		//timer
		//yeah can't get this to work either.
		timer = timer + Time.deltaTime;
     if (timer >= 10)
     {
          endText.text = "You Lose lmao >:]";
          StartCoroutine(ByeAfterDelay(2));

     }

	}
	
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag("PickUp"))
		{	
			other.gameObject.SetActive(false);
			count = count + 2;
			//I can't get this to work help me?
			//GameLoader.AddScore(1);
			SetCountText ();
			meowSource.Play();
		}
	}
	void SetCountText()
	{
		 countText.text = "Count: " + count.ToString ();
		 if (count >= 10)
		 {
			 customImage.enabled = true;
			 StartCoroutine(ByeAfterDelay(2));
		 }
		 
	}
	IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay 
		// What the heck even is gameloader someone tell me i have no idea what im doing.
        //GameLoader.gameOn = false;
    }
}
