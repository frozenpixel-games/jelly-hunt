using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletManager : MonoBehaviour
{
	public float speed = 20;
	public Rigidbody2D rb;
	public GameObject splatter;

	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * speed;
		Destroy(gameObject, 2);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag != "Player" || collision.gameObject.tag != "Friendly")
		{
			StartCoroutine(DestroyBullet());
		}

		if (collision.gameObject.CompareTag("Boss"))
		{
			StartCoroutine(DestroyBullet());
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("Enemy"))
		{
			StartCoroutine(DestroyBullet());
			other.tag = "Friendly";
		}
	}

	IEnumerator DestroyBullet()
    {
		Instantiate(splatter, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);

		yield return new WaitForSeconds(0.02f);

		Destroy(gameObject);
	}
}