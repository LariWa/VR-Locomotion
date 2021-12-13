using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class QuantitiveEvaluator : MonoBehaviour
{
    Vector3 prevPos;
    public Transform player;
    public bool applicationStarted;
    List<float> speed = new List<float>();
    List<float> distance = new List<float>();


    private void Start()
    {
        prevPos = player.position;

    }
    private void FixedUpdate()
    {
        if(applicationStarted)
       //Speed     
        speed.Add(getSpeed(player.position));
        distance.Add(getDistance(player.position));
        prevPos = player.position;


    }
   public void applicationIsStarted()
    {
        applicationStarted = true;
    }
    private float getSpeed(Vector3 currentPos)
    {
        float movementPerFixedUpdate = Vector3.Distance(prevPos, currentPos);
      
        return movementPerFixedUpdate / Time.fixedDeltaTime;
    }
    private float getDistance(Vector3 currentPos)
    {
        float movementPerFixedUpdate = Vector3.Distance(prevPos, currentPos);
        return movementPerFixedUpdate ;
    }
    private void OnDestroy()
    {
        Save();
    }

    void Save()
    {
        List<List<string>> data = new List<List<string>>();

        // set titles
        List<string> dataTemp = new List<string>(new string[] {
        "speed",
        "distance",

         });
        data.Add(dataTemp);
        float allSpeed = 0;
        float allDistances = 0;
        for (int index = 0; index < speed.Count; index++)
        {
            allSpeed += speed[index];
            allDistances += distance[index];
        }
         dataTemp = new List<string>();
       
        //average speed
        dataTemp.Add((allSpeed / speed.Count).ToString());
        dataTemp.Add((allDistances).ToString());
        data.Add(dataTemp);
      

        //write to file       
        int length = data.Count;
        string delimiter = ";";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, data[index]));
        print(Application.dataPath);
        string filePath = Application.dataPath + "/quantitiveMetrics" + DateTime.Now.ToString("yyyyMMddHHmmssfff")+".csv";

        StreamWriter outStream = File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }
}

