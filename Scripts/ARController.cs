using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class ARController : MonoBehaviour {

    /// <summary>
    /// A list to hold new planes ARCore began tracking in the current frame. This object is used across
    /// the application to avoid per-frame allocations.
    /// </summary>
    private List<TrackedPlane> m_NewPlanes = new List<TrackedPlane>();

    public GameObject TrackedPlanePrefab;
    public GameObject Pokemon;
    public GameObject ARCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
      // Check ARCore session status
      if(Session.Status != SessionStatus.Tracking) {
        return;
      }

      Session.GetTrackables<TrackedPlane>(m_NewPlanes, TrackableQueryFilter.New);
      for (int i = 0; i < m_NewPlanes.Count; i++)
      {
          // Instantiate a plane visualization prefab and set it to track the new plane. The transform is set to
          // the origin with an identity rotation since the mesh for our prefab is updated in Unity World
          // coordinates.
          GameObject planeObject = Instantiate(TrackedPlanePrefab, Vector3.zero, Quaternion.identity,
              transform);
          planeObject.GetComponent<GridVisualizer>().Initialize(m_NewPlanes[i]);
      }

      // Check if user touched the screen
      Touch touch;
      if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began) {
        return;
      }

      // Check if user touched a tracked plane
      TrackableHit hit;
      if(Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit)) {
        // Place entity on top of tracked plane

        //Enable the entity
        Pokemon.SetActive(true);

        // Create a new Anchor
        Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

        // Set poisiton of the pokemon to be the same as hit position
        Pokemon.transform.position = hit.Pose.position;
        Pokemon.transform.rotation = hit.Pose.rotation;

        // Pokemon face camera
        Vector3 cameraPosition = ARCamera.transform.position;

        // Pokemon only rotate around Y Axis
        cameraPosition.y = hit.Pose.position.y;

        // Rotate the pokemon to face the camera
        Pokemon.transform.LookAt(cameraPosition, Pokemon.transform.up);

        Pokemon.transform.parent = anchor.transform;

      }

    }
}
