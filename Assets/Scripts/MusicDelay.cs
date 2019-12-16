 using UnityEngine;
 using System.Collections;
 
 [RequireComponent(typeof(AudioSource))]
 public class MusicDelay: MonoBehaviour
 {
     public AudioSource audioSourceIntro;
     public AudioSource audioSourceLoop;
     private bool startedLoop;
 
     void FixedUpdate()
     {
         if (!audioSourceIntro.isPlaying && !startedLoop)
         {
             audioSourceLoop.Play();
             Debug.Log("Done playing");
             startedLoop = true;
         }
     }
 }
