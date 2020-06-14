using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DockingSim
{
    public class Vessel : MonoBehaviour
    {
        public List<Transform> rcsBlocks;
        public Vessel target;
        private Rigidbody vesselRigidbody;
        public Vector3 initialVelocity;

        // Start is called before the first frame update
        void Start()
        {
            //rcsBlocks.AddRange(GameObject.FindGameObjectsWithTag("RCSBlock"));
            vesselRigidbody = gameObject.GetComponentInChildren<Rigidbody>();
            vesselRigidbody.AddForce(initialVelocity, ForceMode.Acceleration);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                vesselRigidbody.AddForce(0.1f, 0, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
               vesselRigidbody.AddForce(-0.1f, 0, 0);
            }

        }
    }
}
