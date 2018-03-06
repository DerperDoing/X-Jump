using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPooler : MonoBehaviour {
	private float y;
	[System.Serializable]
	public class Pool
	{
		public string tag;
		public GameObject prefab;
		public int size;
	}

	public static PlatformPooler Instance;
	private void Awake()
	{
		Instance = this;
	}

	public Dictionary<string,Queue<GameObject>> poolDictionary;
	public List<Pool> lPools;
	void Start () {
		poolDictionary=new Dictionary<string, Queue<GameObject>>();
		foreach (Pool cPool in lPools) {
			Queue<GameObject> qPool = new Queue<GameObject> ();
			for (int i = 0; i < cPool.size; i++) {
				GameObject g = Instantiate (cPool.prefab);
				g.SetActive (true);
				qPool.Enqueue (g);
			}
			poolDictionary.Add (cPool.tag, qPool);
		}
	}

	public GameObject SpawnFromPool(string tag, Vector2 pos)
	{

		if(poolDictionary[tag].Count>0){
			if (!poolDictionary.ContainsKey (tag)) {
				return null;
			}
			GameObject objToSpawn = poolDictionary [tag].Dequeue();
			objToSpawn.SetActive (true);
			objToSpawn.transform.position = pos;
			poolDictionary [tag].Enqueue (objToSpawn);
			return objToSpawn;
		}
		Debug.Log ("Null se pehle");
		return null;
	}
}
