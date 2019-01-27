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

    }
}
