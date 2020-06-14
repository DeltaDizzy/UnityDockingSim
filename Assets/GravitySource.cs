using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DockingSim
{
    public class GravitySource : MonoBehaviour
    {
        public float mass;
        public float gravConstant = 1;

        void OnTriggerStay(Collider other)
        {
            Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (otherRigidbody)
            {
                Vector3 diff = gameObject.transform.position - other.gameObject.transform.position;
                float dist = diff.magnitude;
                Vector3 gravDir = diff.normalized;
                Vector3 gravVector = (gravDir * mass * gravConstant) / (dist * dist);

                otherRigidbody.AddForce(gravVector, ForceMode.Acceleration);
            }
        }
    }
}
