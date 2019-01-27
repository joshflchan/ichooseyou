using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class backgroundmusic : MonoBehaviour, ITrackableEventHandler
{

  private AudioSource bg_music;
  bool audioPlayed = false;

  private TrackableBehaviour mTrackableBehaviour;
    // Start is called before the first frame update
    void Start()
    {
      bg_music = GetComponent<AudioSource>();
      mTrackableBehaviour = GetComponent<TrackableBehaviour>();
      if (mTrackableBehaviour)
      {
        mTrackableBehaviour.RegisterTrackableEventHandler(this);
      }
    }

    public void OnTrackableStateChanged(
      TrackableBehaviour.Status previousStatus,
      TrackableBehaviour.Status newStatus)
    {
      if  (!audioPlayed && (newStatus == TrackableBehaviour.Status.DETECTED ||
           newStatus == TrackableBehaviour.Status.TRACKED ||
           newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED))
      {
        bg_music.Play();
        audioPlayed = true;
      }
      else
      {
        // audio.Stop();
      }
   }



    // Update is called once per frame
    void Update()
    {

    }
}
