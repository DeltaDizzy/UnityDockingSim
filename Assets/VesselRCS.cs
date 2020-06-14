using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DockingSim
{
    [RequireComponent(typeof(Vessel))]
    public class VesselRCS : MonoBehaviour
    {
        public List<Transform> thrusterTransforms = new List<Transform>();

        private List<Transform> activeTransforms = new List<Transform>();
        public string thrusterTransformName = "RCSThruster";
        public float thrusterPower = 1f;

        public Rigidbody rb;

        private Direction wantedDirection;
        private Vector3Int[] directionVectors = new Vector3Int[]
            { new Vector3Int(0,1,0), new Vector3Int(0,-1,0), new Vector3Int(0,0,1), 
            new Vector3Int(0,0,-1), new Vector3Int(1,0,0), new Vector3Int(-1,0,0) };

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
            GetActiveTransforms(wantedDirection);
            ApplyThrust();
            activeTransforms.Clear();
            wantedDirection = null;

        }

        public void GetTranslation()
        {
            // Figure out which way we want to go
            if (Input.GetKey(KeyCode.I)) // up
            {
                wantedDirection = Direction.UP;
            }
            if (Input.GetKey(KeyCode.J)) // left
            {
                wantedDirection = Direction.LEFT;
            }
            if (Input.GetKey(KeyCode.L)) // right
            {
                wantedDirection = Direction.RIGHT;
            }
            if (Input.GetKey(KeyCode.K)) // down
            {
                wantedDirection = Direction.DOWN;
            }
            if (Input.GetKey(KeyCode.H)) // fore
            {
                wantedDirection = Direction.FORE;
            }
            if (Input.GetKey(KeyCode.N)) // back
            {
                wantedDirection = Direction.AFT;
            }
        }
        
        public void GetActiveTransforms(Direction dir)
        {
            for (int i = 0; i < thrusterTransforms.Count; i++)
            {
                if (Vector3.Dot(thrusterTransforms[i].forward, directionVectors[(int)dir]) > -0.5)
                {
                    activeTransforms.Add(thrusterTransforms[i]);
                }
            }
        }

        public void ApplyThrust()
        {
            for (int i = 0; i < activeTransforms.Count; i++)
            {
                rb.AddForceAtPosition(activeTransforms[i].forward * thrusterPower, activeTransforms[i].forward, ForceMode.Acceleration);
            }
        }
        public enum Direction {LEFT,RIGHT,UP,DOWN,FORE,AFT,NONE}
    }

}