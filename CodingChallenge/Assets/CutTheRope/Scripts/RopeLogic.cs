using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CutTheRope {
    
    public class RopeLogic : MonoBehaviour {

        public Rigidbody2D ball;
        private List<HingeJoint2D> joints = new List<HingeJoint2D>();
        private List<Vector3> points = new List<Vector3>();
        [SerializeField] LineRenderer lineRenderer;
        public GameObject joint;
        public float distanceToInstance;
        [SerializeField] GameObject lastJoint;
        private HingeJoint2D lastJointComponent;
        private bool isDestroyed;
        
        // Start is called before the first frame update
        void Start() {
            joints.Add( lastJoint.GetComponent<HingeJoint2D>()); 
            lastJointComponent = lastJoint.GetComponent<HingeJoint2D>();
            //SetPointToLine(transform.position);
            //SetPointToLine(lastJoint.transform.position);
        }

        // Update is called once per frame
        void Update() {
            
            if (isDestroyed) {
                return;
            }

            if (Vector2.Distance(lastJoint.transform.position,ball.transform.position)> distanceToInstance) {
                CreateNode(ball.transform.position);
                lastJoint.GetComponent<HingeJoint2D>().connectedBody = ball;
            }
            
            // if (Mathf.Abs( lastJoint.transform.position.y - ball.transform.position.y) > distanceToInstance) {
            //     var lastJointPosY = lastJoint.transform.position.y;
            //     var lastJointScaleY = lastJoint.transform.localScale.y;
            //     var posX = ball.transform.position.x - transform.position.x;
            //     var jointInstanciated = Instantiate(joint, new Vector3(posX, lastJointPosY - lastJointScaleY), Quaternion.identity, transform);
            //     var jointComponentInstance = jointInstanciated.GetComponent<HingeJoint2D>();
            //     lastJointComponent.connectedBody = jointComponentInstance.GetComponent<Rigidbody2D>();
            //     jointComponentInstance.connectedBody = ball;
            //     joints.Add(jointComponentInstance);
            //     lastJoint = jointInstanciated;
            //     lastJointComponent = jointComponentInstance;
            // }
        }
        public void CreateNode(Vector2 targetPos)
        {
            Vector2 pos2Create = targetPos - (Vector2)lastJoint.transform.position;
            pos2Create.Normalize();
            pos2Create *= distanceToInstance;
            pos2Create += (Vector2)lastJointComponent.transform.position;
            GameObject go = (GameObject) Instantiate(joint, pos2Create, Quaternion.identity);
            go.transform.SetParent (transform);
            lastJointComponent.connectedBody = go.GetComponent<Rigidbody2D> ();
            lastJoint = go;
            lastJointComponent = lastJoint.GetComponent<HingeJoint2D>();
            //lastNode.GetComponent<HingeJoint2D>().useLimits = true;
            joints.Add (lastJoint.GetComponent<HingeJoint2D>());
            //SetPointToLine(go.transform.position);
        }
        
        
        private void SetPointToLine(Vector3 pos) {
            // var pos =mainCamera.ScreenToWorldPoint(mousePos);
            points.Add(pos);
            var positionCount = points.Count;
            lineRenderer.positionCount = positionCount;
            lineRenderer.SetPosition(positionCount - 1, pos);
        }


        public void DestroyAllJoint() {
            isDestroyed = true;
            foreach (var j in joints) {
                j.gameObject.SetActive(false);
            }
        }


        public bool IsJointInRope(HingeJoint2D hingeJoint2D) {
            return joints.Contains(hingeJoint2D);
        }
    }
    
    
    

}
