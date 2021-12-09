using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 ) {
      if (audioData.isPlaying == false){
          audioData.volume = Random.Range(0.2f,0.25f);
          audioData.pitch = Random.Range(0.7f,0.8f);
          audioData.Play(0);
      }
    }
  }
}
