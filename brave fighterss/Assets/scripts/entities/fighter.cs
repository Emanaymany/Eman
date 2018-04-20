using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighter : MonoBehaviour
{
	public enum PlayerType
	{
		Human, AI
	};

	public static float max_health = 100f;
	public float healt = max_health;
	public string fightername;
	public fighter oponent;
	protected Animator animator;
	private Rigidbody mybody;
    private AudioSource audioplayer;

	public PlayerType player;

	public fighterstate CurrentState = fighterstate.IDLE;
	// Use this for initialization
	void Start()
	{
		mybody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
        audioplayer = GetComponent<AudioSource>();
	}

	public void UpdateHumanInput ()
	{
		if (Input.GetAxis ("Horizontal") > 0.1) {
			animator.SetBool ("WALK", true);
		} else {
			animator.SetBool ("WALK", false);
		}

		if (Input.GetAxis ("Horizontal") < -0.1) {
			animator.SetBool ("WALK_BACK", true);
		} else {
			animator.SetBool ("WALK_BACK", false);
		}

		if (Input.GetAxis ("Vertical") < -0.1) {
			animator.SetBool ("DUCK", true);
		} else {
			animator.SetBool ("DUCK", false);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			animator.SetTrigger ("JUMP");
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			animator.SetTrigger ("PUNSH");
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			animator.SetTrigger ("KICK");
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			animator.SetTrigger ("HADOKEN");
		}


	}
	// Update is called once per frame
	void Update()
	{
		animator.SetFloat("health", healtpercent);
		if (oponent != null)
		{
			animator.SetFloat("oponent_health", oponent.healtpercent);
		}
		else
		{
			animator.SetFloat("oponent_health", 1);
		}
		if ( player == PlayerType.Human)
		{
			UpdateHumanInput();
		}
	}
    public void PlaySounds(AudioClip sound)
    {
        GameUtlis.playsound(sound, audioplayer);

    }

	public float healtpercent
	{

		get
		{
			return healt / max_health;
		}
	}

	public Rigidbody body
	{
		get
		{
			return this.mybody;
		}
	}
}



