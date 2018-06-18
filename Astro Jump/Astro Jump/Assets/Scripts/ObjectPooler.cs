using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
	
	public GameObject platforms;
	public int[] prob={8,2,4}; //Pobability of each type of platforms.Used below in weighted random  number generator

	[System.Serializable] //Serializable so that visible in Inspectoer and can be manually edited there.
	public class PrefabsData //Holds prefab of different types of platforms and their total count to be used
	{
		public GameObject prefab;
		public int size;
	}

	public List<PrefabsData> prefabsList; //List of different platform prefabs
	public List<List<GameObject>> pooledObjects; //List of lists that has platforms of different prefabs

	bool place=false;

	public float xPos,yPos=0.1f; //Values used
	public float xRange=2;      //for randomising 
	public float yMin=0.01f;   //platform
	public float yMax= 1;     //locations

	public void Start () {
		pooledObjects=new List<List<GameObject>>();
		foreach (PrefabsData pd  in prefabsList){
			List<GameObject> pO=new List<GameObject>(); //Creating a list for each type of platform prefab
			for (int j = 0; j <pd.size; j++) {
				GameObject o = (GameObject)Instantiate(pd.prefab); //Above list populated with the gameobjects(platofrms)
				o.SetActive (false);	//Set false so that not visible on screen when created.
				pO.Add(o);
			}
			pooledObjects.Add (pO); //After populating, list added to the list of lists created above.
		}
	}

	void Update () {
		GetPlatform(); //Call to get a platform
		if (place) { //Runs only when place is set True in GetPlatform() so that values of x and y don't keep on updating every frame else*
			xPos = Random.Range (-xRange, xRange); // *there will be huge gaps between the platforms.
			platforms.transform.position = new Vector2 (xPos, yPos); //Platform positioned at random position on screen
			platforms.SetActive (true); //Made visible on screen
			yPos += Random.Range (yMin, yMax);
			place = false;
		}
	}


	public void GetPlatform() {
		/*Implementing Weighted Random Number
		 To implement we'll use an array which will contain chances of each of them(for below example, length will be 3). MUST BE SORTED.
			-------------------------------------------------
			|		|		|		|		|		|		|
			|	A	|	A	|	A	|	B	|	B	|	C	| 
			------------------------------------------------
			Chances of getting A=3, B= 2, C=1 and Total=6
			Suppose we generate a random number between 0 and Total(ie 6) and get random=4
			In loop, we keep on adding the weights(chances) per iteration,ie, 
				for 1st iteration here, sum will be 3
				for 2nd iteration, sum=3+2=5
				for 3rd iteration, sum=5+1=6
			Moreover, in each iteration we check if value of random < sum. If yes, we return that else go to next iteration.
			Here, random !< smaller in 1st iteration, since 4 !< 3
			But in next iteration, random < sum, 4 < 5. Thus,we return B.

		*/
		int ind = Random.Range (0, 100); 
		print (ind);
		int cummulative = 0;
		for (int i = 0; i < prob.Length; i++) {
			cummulative += prob [i];
			print ("Cum=" + cummulative);
			if (ind < cummulative) {
				for (int j = 0; j < pooledObjects [i].Count; j++) {	//This for loop is used to find the gameobject which is not active in the hierarchy
					if (!pooledObjects [i] [j].activeInHierarchy) {
						platforms = pooledObjects [i] [j];		//When found, it is returned
						place = true;
					}
				}
				break;
			}
		}
			
		
	}
}
