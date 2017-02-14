using UnityEngine;
using System.Collections;

public class BGmusic : MonoBehaviour
{

	AudioSource audio;
	float alpha = 1.0f;
	public  AudioClip[] PlayList;
	public float fadeSpeed = 2.0f;


	void Awake()
	{
		audio = GetComponent<AudioSource>();
		audio.volume = 0.25f;

	}

	void Start()
	{
		if (!audio.playOnAwake)
			audio.clip = PlayList[Random.Range(0, PlayList.Length)] as AudioClip; 
		audio.Play();
		StartCoroutine(Fade());
	}


	void Update()
	{

		if (!audio.isPlaying)
		{
			playRandomMusic();
			StartCoroutine(Fade());
		}
	}

	void playRandomMusic()
	{
		audio.clip = PlayList[Random.Range(0, PlayList.Length)] as AudioClip;
		audio.Play();
	}

	IEnumerator Fade()
	{
		alpha = 0;
		while (alpha < 1f)
		{
			alpha += Time.deltaTime * fadeSpeed;
			yield return null;  
		}
		StartCoroutine(FadeOUT());
	}

	IEnumerator FadeOUT()
	{

		yield return new WaitForSeconds(10);
		while (alpha > 0f)
		{
			alpha -= Time.deltaTime * fadeSpeed;
			yield return null;
		}

	}

}