using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DockingSim
{
    [RequireComponent(typeof(Vessel))]
    public class VesselRCS : MonoBehaviour
    {
        public List<Transform> thrusterTransforms = new List<Transform>();
        public string thrusterTransformName = "RCSThruster";
        public float thrusterPower = 1f;

        public Rigidbody rb;

        private Vector3 wantedDirection;

        // Start is called before the first frame update
        void Start()
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag(thrusterTransformName))
            {
                thrusterTransforms.Add(go.transform);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            GetTranslation();
            ApplyThrust();
            if (!Input.anyKey)
            {
                wantedDirection = Vector3.zero;
            }
        }

        public void GetTranslation()
        {
            // Figure out which way we want to go

            wantedDirection = new Vector3(Input.GetAxis("DockingXTranslate"), Input.GetAxis("DockingYTranslate"), Input.GetAxis("DockingZTranslate"));
            wantedDirection.Normalize();
            gameObject.transform.localToWorldMatrix.MultiplyVector(wantedDirection);
        }
        

        public void ApplyThrust()
        {
            for (int i = 0; i < thrusterTransforms.Count; i++)
            {
                if (Vector3.Dot(thrusterTransforms[i].forward, wantedDirection) > -0.5)
                {
                    rb.AddForceAtPosition(thrusterTransforms[i].forward * thrusterPower, thrusterTransforms[i].forward, ForceMode.Acceleration);
                }
            }
        }
    }

}