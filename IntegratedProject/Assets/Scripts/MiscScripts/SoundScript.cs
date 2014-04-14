using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

	public AudioSource au_death;
	public AudioSource au_shoot;
	public AudioSource au_BGM;
    public AudioSource au_pickup;
    public AudioSource au_jump;
    public AudioSource au_playerhit;


	// Use this for initialization
	void Start () 
	{
		AudioClip shootSound;
		shootSound = (AudioClip)Resources.Load ("SFX/shoot");

        AudioClip hitSound;
        hitSound = (AudioClip)Resources.Load("SFX/playerhit");

        AudioClip pickupSound;
        pickupSound = (AudioClip)Resources.Load("SFX/pickup");

		AudioClip deathSound;
		deathSound = (AudioClip)Resources.Load ("SFX/death");

        AudioClip jumpSound;
        jumpSound = (AudioClip)Resources.Load("SFX/jump");

		AudioClip bgmSound;
		bgmSound = (AudioClip)Resources.Load ("Music/IP bgm");

		au_shoot = (AudioSource)gameObject.AddComponent("AudioSource");
		au_shoot.clip = shootSound;
		au_shoot.loop = false;

		au_death = (AudioSource)gameObject.AddComponent("AudioSource");
		au_death.clip = deathSound;
		au_death.loop = false;

        au_pickup = (AudioSource)gameObject.AddComponent("AudioSource");
        au_pickup.clip = pickupSound;
        au_pickup.loop = false;

        au_jump = (AudioSource)gameObject.AddComponent("AudioSource");
        au_jump.clip = jumpSound;
        au_jump.loop = false;

        au_playerhit = (AudioSource)gameObject.AddComponent("AudioSource");
        au_playerhit.clip = hitSound;
        au_playerhit.loop = false;

		au_BGM = (AudioSource)gameObject.AddComponent("AudioSource");
		au_BGM.clip = bgmSound;
		au_BGM.loop = true;
        au_BGM.volume = 0.25f;
		au_BGM.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown(0))
		{
			au_shoot.Play();
		}
	}

	void SoundOnDeath()
	{
		Debug.Log ("SoundOnDeath");
	}
}
