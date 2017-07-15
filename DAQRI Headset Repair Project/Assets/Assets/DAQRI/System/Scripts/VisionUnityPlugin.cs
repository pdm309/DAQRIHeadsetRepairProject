﻿/****************************************************************************************************************************************
 * © 2016 Daqri International. All Rights Reserved.                                                                                     *
 *                                                                                                                                      *
 *     NOTICE:  All software code and related information contained herein is, and remains the property of DAQRI INTERNATIONAL and its  *
 * suppliers, if any.  The intellectual and technical concepts contained herein are proprietary to DAQRI INTERNATIONAL and its          *
 * suppliers and may be covered by U.S. and Foreign Patents, patents in process, and/or trade secret law, and the expression of         *
 * those concepts is protected by copyright law. Dissemination, reproduction, modification, public display, reverse engineering, or     *
 * decompiling of this material is strictly forbidden unless prior written permission is obtained from DAQRI INTERNATIONAL.             *
 *                                                                                                                                      *
 *                                                                                                                                      *
 *                                                                                                                                      *
 *     File Purpose:        <todo>                                                                                                      *
 *                                                                                                                                      *
 *     Guide:               <todo>                                                                                                      *
 *                                                                                                                                      *
 ****************************************************************************************************************************************/

using UnityEngine;
using System.Collections;
using System;

namespace DAQRI {
	
	public class VisionUnityPlugin : IVisionUnityPlugin {

		private const int SOFTWARE_MODE = 0;
		private const int HARDWARE_MODE = 1;

		// Singleton
		private static VisionUnityPlugin instance;
		public static VisionUnityPlugin Instance {
			get {
				if (instance == null) {
					instance = new VisionUnityPlugin ();
				}

				return instance;
			}
		}


		public bool InitAR(string[] markerPath, int numMarkers,float[] width, float[]height, int[] markerIds) {
			return VisionUnityAbstraction.L7_TrackerStart (markerPath, numMarkers, width, height, markerIds, SOFTWARE_MODE);
		}
		
		public bool UpdateAR() {
			return VisionUnityAbstraction.L7_TrackerUpdate ();
		}

		public bool StopAR() {
			return VisionUnityAbstraction.L7_TrackerStop ();
		}

		public bool GetPose (ref Vector3 position, ref Quaternion orientation, int markerId) {
			float[] pos = new float[3];
			float[] rot = new float[4];

			bool ret = VisionUnityAbstraction.L7_TrackerGetTrackablePose(pos, rot, markerId);

			if(ret) {
				position.Set(pos[0],pos[1],pos[2]);
				orientation.Set(rot[0],rot[1],rot[2], rot[3]);
			}

			return ret;
		}

	    public Matrix4x4 GetProjectionMatrix(ProjectionMatrixEye eye) {
	        return DSHUnityPlugin.Instance.GetProjectionMatrix(eye);
	    }

    }
}
