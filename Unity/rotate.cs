using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class rotate : MonoBehaviour
{
	[SerializeField]
	private float speed = 5.0f;
	[SerializeField]
	Vector3 direction = Vector3.right;
	[SerializeField]
	int n_frame = 100;
	Coroutine flipper = null;
	Quaternion origin;
	void Start()
	{
		origin = transform.rotation;
	}
	IEnumerator Flip(int n_frame)
	{
		while (n_frame > 0 || (transform.rotation != origin))
		{
			transform.Rotate(direction * speed);
			n_frame--;
			yield return null;
		}
		transform.rotation = origin;
		flipper = null;
	}
	void OnMouseUp()
	{

		if (flipper != null) return;
		if (!EventSystem.current.IsPointerOverGameObject())
			flipper = StartCoroutine(Flip(n_frame)); 

	}
}
//IEnumerator OnMouseUp()
		//{
		//	int n_frame = 100;
		//	while (n_frame > 0 || (transform.rotation != origin))
		//	{
		//		transform.Rotate(Vector3.right * speed);
		//		n_frame--;
		//		yield return null;
		//	}
		//	transform.rotation = origin;
		//	flipper = null;
		//}	