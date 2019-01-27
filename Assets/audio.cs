using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class audio : MonoBehaviour, ITrackableEventHandler
{

  public AudioSource m_MyAudio;
  public AudioSource song;

  bool audioPlayed = false;
  bool songPlayed = false;

  private TrackableBehaviour mTrackableBehaviour;
    // Start is called before the first frame update
    void Start()
    {
      m_MyAudio = GetComponent<AudioSource>();
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
        // audio.Play();
        m_MyAudio.Play();
          if (song && !songPlayed){

            song.Play();
            songPlayed = true;
          }
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
