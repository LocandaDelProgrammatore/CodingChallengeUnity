using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CutTheRope;
using UnityEngine;


namespace CutTheRope {

	public class InteractionLogic : MonoBehaviour {

		private Camera camera;
		private List<RopeLogic> ropeLogics;

		private void Awake() {
			camera = FindObjectOfType<Camera>();
			ropeLogics = FindObjectsOfType<RopeLogic>().ToList();
		}

		private void Update() {
			if (Input.GetMouseButtonDown(0)) {
				Vector2 pos = camera.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D raycastHit2D = Physics2D.Raycast(pos,-Vector2.up,100);
				Debug.DrawLine(pos,-Vector2.up*100);

				if (raycastHit2D.collider != null) {
					Debug.Log(raycastHit2D.collider.name);
				}

				if (raycastHit2D.collider == null) {
					return;
				}
				foreach (var rope in ropeLogics) {
					if (rope.IsJointInRope(raycastHit2D.collider.GetComponent<HingeJoint2D>())) {
						rope.DestroyAllJoint();
						break;
					}
				}
			}
		}
	}

}