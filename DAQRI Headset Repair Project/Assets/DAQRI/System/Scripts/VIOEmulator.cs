﻿using UnityEngine;
using System.Collections;

namespace DAQRI {
	
	public class VIOEmulator : MonoBehaviour {

		public float movementSpeed = 1.0f;
		public float mouseLookSensitivity = 360.0f;

		private Vector3 position = Vector3.zero;
		private Quaternion quat = Quaternion.identity;

		void Start () {
			position = transform.position;
		}

		void Update () {
			UpdatePosition ();

			if (Input.GetMouseButton (0)) {
				Cursor.visible = false;
				UpdateOrientation ();
			} else {
				Cursor.visible = true;
			}
		}

		private void UpdatePosition () {

			float forwardMovement = Input.GetAxis ("Vertical") * movementSpeed * Time.deltaTime;
			float sideMovement = Input.GetAxis ("Horizontal") * movementSpeed * Time.deltaTime;

			Vector3 forwardDirection = quat * Vector3.forward;
			forwardDirection.y = 0.0f;
			forwardDirection.Normalize ();

			Vector3 sideDirection = quat * Vector3.right;
			sideDirection.y = 0.0f;
			sideDirection.Normalize ();

			position += forwardDirection * forwardMovement;
			position += sideDirection * sideMovement;

			ServiceManager.Instance.SimulateIMUPosition (position);
		}

		private void UpdateOrientation () {
			float xAxisRotation = Input.GetAxis ("Mouse Y") * -mouseLookSensitivity * Time.deltaTime;
			float yAxisRotation = Input.GetAxis ("Mouse X") * mouseLookSensitivity * Time.deltaTime;
			//float zAxisRotation = Input.GetAxis ("Mouse ScrollWheel") * mouseLookSensitivity;
			float zAxisRotation = 0.0f;

			Vector3 xAxis = quat * Vector3.right;
			Vector3 zAxis = quat * Vector3.forward;
			quat = Quaternion.AngleAxis (xAxisRotation, xAxis) * quat;
			quat = Quaternion.AngleAxis (yAxisRotation, Vector3.up) * quat;
			quat = Quaternion.AngleAxis (zAxisRotation, zAxis) * quat;

			Vector3 deltas = new Vector3 (xAxisRotation, yAxisRotation, zAxisRotation);

			//TODO remove _imuQuaternion getting changed in multiple locations (ServiceManager) - NG
			ServiceManager.Instance.SimulateIMU (deltas, quat);
		}
	}
}
