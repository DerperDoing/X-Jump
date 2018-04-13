using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public static ObjectPooler instance;

	void Awake()
	{
		instance = this;
	}
	public GameObject prefab,platforms;
	public int size;
//	public List<GameObject> plat;
	public Queue<GameObject> plat;
//	bool willGrow=true;

//	public GameObject op;
	public float xPos,yPos=0.1f;
	public float xRange=2;
	public float yMin=0.01f;
	public float yMax= 1;

	public void Start () {
		plat = new Queue<GameObject> ();
		for (int i = 0; i < size; i++) {
			GameObject o = (GameObject)Instantiate(prefab);
			o.SetActive (false);
			plat.Enqueue(o);
		}
	}

	void FixedUpdate () {
//		xPos = Random.Range (-xRange, xRange);
//		GameObject
//		platforms=GetPlatform ();
		GetPlatform();
		platforms.transform.position = new Vector2 (0, yPos);
		platforms.SetActive (true);
//		yPos += Random.Range (yMin, yMax);
	}


	public void GetPlatform() {
//		print (plat.Count);
//		int i=0;
//		for (i = 0; i < plat.Count; i++) {
//			if (!plat [i].activeInHierarchy) {
//				print ("returning plat");
//				return plat [i];
//			}
//		}
//
//		if (willGrow) {
//			print ("Growing");
//			GameObject o = (GameObject)Instantiate (prefab);
//			plat.Add (o);
//			return o;
//		}
//		return null;
//		if (plat.Count<1) 
//		{
//			GameObject o = (GameObject)Instantiate(prefab);
//			o.SetActive (false);
//			plat.Enqueue(o);
//			print("Low Count"
//		}
		try {
			platforms=plat.Dequeue ();
			yPos += Random.Range (yMin, yMax);
		} catch (System.Exception ex) {
			Debug.LogException (ex,this);
		}

	}

	public void DeletePlatform(GameObject go)
	{
		go.SetActive (false);
		plat.Enqueue (go);
	}
}
