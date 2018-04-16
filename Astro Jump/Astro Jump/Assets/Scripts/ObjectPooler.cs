using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
	
	public GameObject platforms;
//	public GameObject prefab,platforms;
//	public int size;
	[System.Serializable]
	public class PrefabsData
	{
		public GameObject prefab;
		public int size;
	}

	public List<PrefabsData> prefabsList;
	public List<List<GameObject>> pooledObjects;

	bool place=false;

	public float xPos,yPos=0.1f;
	public float xRange=2;
	public float yMin=0.01f;
	public float yMax= 1;

	public void Start () {
		prefabsList=new List<PrefabsData>();
		pooledObjects=new List<List<GameObject>>();
		for(int i=0;i<prefabsList.Count;i++) {
			print ("Value of i: "+ i);
			for (int j = 0; j <prefabsList[i].size; j++) {
				print ("Value of j: "+j);
				GameObject o = (GameObject)Instantiate(prefabsList[i].prefab);
				o.SetActive (false);
				pooledObjects[i].Add(o);
			}
		}
	}

	void Update () {
		GetPlatform();
		if (place) {
			xPos = Random.Range (-xRange, xRange);
			platforms.transform.position = new Vector2 (0, yPos);
			platforms.SetActive (true);
			yPos += Random.Range (yMin, yMax);
			place = false;
		}
	}


	public void GetPlatform() {
		int ind = Random.Range (0, pooledObjects.Count-1);
		for (int i = 0; i < pooledObjects[ind].Count; i++) {
			if (!pooledObjects[ind][i].activeInHierarchy) {
				platforms=pooledObjects[ind][i];
				place = true;
			}
		}
	}
}
