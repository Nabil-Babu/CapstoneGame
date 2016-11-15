using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Image currentHealthImage;
	public Text ratioText;

	private float hitpoint = 150;
	private float maxHitpoint = 150;

	private void Start()
	{
		UpdateHealthbar ();
	}

	private void UpdateHealthbar()
	{
		float ratio = hitpoint / maxHitpoint;
		currentHealthImage.rectTransform.localScale = new Vector3 (ratio,1,1);
		ratioText.text = (ratio * 100).ToString () + '%';
	}

	private void TakeDamage(float damage)
	{
		hitpoint -= damage;
		if (hitpoint < 0) {
			hitpoint = 0;
			Debug.Log ("Dead!");
		}

		UpdateHealthbar ();
	}


}
