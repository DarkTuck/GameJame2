using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	public static ObjectPooler Instance;
	public GameObject[] objectsToPool;
	public Transform objectsParent;

	public List<GameObject> pooledObjects;
	public int amount;

	void Awake()
	{
		Instance = this;
		foreach (GameObject prefab in objectsToPool)
		{
			for (int i = 0; i < amount; i++)
			{
				GameObject obj = (GameObject)Instantiate(prefab);
				obj.SetActive(false);
				pooledObjects.Add(obj);
				obj.transform.parent = objectsParent.transform;
				obj.transform.position = objectsParent.transform.position;
			}
		}
	}
	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}
		Debug.Log("Object pooler returned null");
		return null;
	}
	public GameObject GetRandoObject()
    {
		List<GameObject> obj = new List<GameObject>();
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
			{
				obj.Add(pooledObjects[i]);
			}
		}
		Debug.Log("Object pooler returned null");

		if(obj.Count > 0)
			return obj[Random.Range(0, obj.Count)];
		return null;
	}
}
[System.Serializable]
public class ObjectsToPool
{
	public ListOfObjects[] listOfObjects;
	public GameObject objectsParent;
}
[System.Serializable]
public class ListOfObjects
{
	public string name;
	public GameObject prefab;
	public int amountToPool;
	public List<GameObject> pooledObjects;
}