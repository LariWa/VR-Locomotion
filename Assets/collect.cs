using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class collect : MonoBehaviour
{
    public Button RouteA;
    public Button RouteB;
    public Button RouteC;
    public Button test;
    public AudioClip magic;

    List<GameObject> collectItemsA = new List<GameObject>();
    List<GameObject> collectItemsB = new List<GameObject>();
    List<GameObject> collectItemsC = new List<GameObject>();
    int countA = 0;
    int countB = 0;
    int countC = 0;

    // Start is called before the first frame update
    void Start()
    {
      collectItems("Collect_A", collectItemsA);
      collectItems("Collect_B", collectItemsB);
      collectItems("Collect_C", collectItemsC);

        Button btnA = RouteA.GetComponent<Button>();
      Button btnB = RouteB.GetComponent<Button>();
        Button btnC = RouteC.GetComponent<Button>();
        Button btnTest = test.GetComponent<Button>();

      btnA.onClick.AddListener(delegate{selectRoute(collectItemsA);});
      btnB.onClick.AddListener(delegate{selectRoute(collectItemsB);});
      btnC.onClick.AddListener(delegate {selectRoute(collectItemsC);});
      btnTest.onClick.AddListener(hideUI);

    }



    // Update is called once per frame
    void Update()
    {

    }

    void collectItems(String tag, List<GameObject> collection)
    {
      foreach (GameObject collectObj in GameObject.FindGameObjectsWithTag(tag))
      {
        collectObj.SetActive(false);
        collection.Add(collectObj);
      }
    }

    void selectRoute(List<GameObject> collection)
    {
      foreach (GameObject collectObj in collection)
      {
        collectObj.SetActive(true);
      }

      hideUI();
    }

    void hideUI()
    {
      GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");

      foreach(GameObject button in buttons)
      {
        button.SetActive(false);
      }
    }

    void OnTriggerEnter(Collider col)
    {
      if (col.gameObject.CompareTag("Collect_A")) {
        AudioSource.PlayClipAtPoint(magic, transform.position);
        Destroy(col.gameObject, (float) Convert.ToDouble("0.1"));
        countA++;
        Debug.Log(countA);
      }
      if (col.gameObject.CompareTag("Collect_B") )
        {
            AudioSource.PlayClipAtPoint(magic, transform.position);
            Destroy(col.gameObject, (float)Convert.ToDouble("0.1"));
            countB++;
            Debug.Log(countB);
        }
     if (col.gameObject.CompareTag("Collect_C"))
        {
            AudioSource.PlayClipAtPoint(magic, transform.position);
            Destroy(col.gameObject, (float)Convert.ToDouble("0.1"));
            countC++;
            Debug.Log(countC);
        }

    }
}
