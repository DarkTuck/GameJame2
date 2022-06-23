using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGeneratro : MonoBehaviour
{
    #region Singleton
    private static TunnelGeneratro _instance;
    public static TunnelGeneratro Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    public float speed = 1F,offset = 18F;
    List<Transform> activeParts = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        StartCo();
        for(int i=0; i<12; i++)
        {
            activeParts.Add(ObjectPooler.Instance.GetRandoObject().transform);
            activeParts[i].gameObject.SetActive(true);
            activeParts[i].position = new Vector3(0, 0, offset * i);
        }
    }
    public void StartCo()
    {
        StartCoroutine(SpeedOverTime());
    }
    IEnumerator SpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            speed += 0.01f;
            if (speed >= 5f)
            {
                break;
            }
        }
    }
    void Update()
    {
        foreach (Transform activeSegment in activeParts)
        {
           activeSegment.position -= new Vector3(0, 0, offset * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tube")
        {
        Debug.Log(other.gameObject.name);
        GameObject newSegment = ObjectPooler.Instance.GetRandoObject();
        other.gameObject.SetActive(false);
        newSegment.SetActive(true);
        activeParts.Remove(other.gameObject.transform);
        newSegment.transform.position = new Vector3(0, 0, offset ) + activeParts[activeParts.Count-1].position;
        activeParts.Add(newSegment.transform);
        }
    }

}