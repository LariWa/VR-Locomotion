using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class collect : MonoBehaviour
{
    List<GameObject> collectibles = new List<GameObject>();
    int count = 0;
    public AudioClip magic;

    // Start is called before the first frame update
    void Start()
    {

    foreach (GameObject collectObj in GameObject.FindGameObjectsWithTag("Collect"))
    {
      collectObj.SetActive(false);
      collectibles.Add(collectObj);
    }

    selectRandom();
    }



    // Update is called once per frame
    void Update()
    {

    }

    void selectRandom()
    {
      if (count < 5)
      {
        int random = UnityEngine.Random.Range (0, collectibles.Count);
        collectibles[random].SetActive(true);
        collectibles.Remove(collectibles[random]);
      } else {
        Debug.Log("All objects found!");
      }

    }

    void OnTriggerEnter(Collider col)
    {
      if (col.gameObject.CompareTag("Collect")) {
        AudioSource.PlayClipAtPoint(magic, transform.position);
        Destroy(col.gameObject, (float) Convert.ToDouble("0.1"));
        count++;
        selectRandom();
      }
    }
}
