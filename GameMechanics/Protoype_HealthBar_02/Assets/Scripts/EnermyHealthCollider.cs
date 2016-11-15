using UnityEngine;
using System.Collections;

public class EnermyHealthCollider : MonoBehaviour {

	public bool isDamaging;
	public float damage = 10;

private void OnTriggerSaty(Collider col)
{
	if (col.tag == "Player")
		col.SendMessage ((isDamaging) ? "TakeDamage" : "HealthDamage", Time.deltaTime * damage);
}

}