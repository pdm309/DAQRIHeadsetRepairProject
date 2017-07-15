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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using UnityEngine;

namespace DAQRI {
	
	public static class DSHUnityAbstraction {
		// The name of the external library containing the native functions
		#if UNITY_EDITOR
		private const string LIBRARY_NAME = "libunitywrapperspringboard";	

		#else
		private const string LIBRARY_NAME = "unitywrapperspringboard";
		#endif

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_Initialize();

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern bool L7_Dispose();

		// Color Camera
		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern bool L7_CameraStart(int preset);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_CameraUpdatePreset(int preset);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_CameraGetParams(int[] width, int[] height);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_CameraGetData(IntPtr data);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_CameraStop();

		[DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void L7_CameraGetPose([MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] pos, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] rot);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_CameraGetRate(float[] rate);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_CameraGetEffectiveRate(float[] rate);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_CameraGetDataFormat(int[] format, bool requested);

		// Depth Camera
		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern bool L7_DepthStart(int preset);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_DepthUpdatePreset(int preset);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_DepthGetParams(int[] width, int[] height);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_DepthGetData(IntPtr data,bool colorize);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_DepthStop();

		[DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void L7_DepthGetPose([MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] pos, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] rot);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_DepthGetRate(float[] rate);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_DepthGetEffectiveRate(float[] rate);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_DepthGetDataFormat(int[] format, bool requested);

		// Thermal Camera
		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_ThermalStart();

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_ThermalGetParams(int[] width, int[] height);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_ThermalGetData(IntPtr data,int[] width, int[] height);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_ThermalStop();

		[DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void L7_ThermalGetPose([MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] pos, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] rot);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_ThermalGetRate(float[] rate);


		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_ThermalGetEffectiveRate(float[] rate);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_ThermalGetDataFormat(int[] format, bool requested);
	
		// Imu
		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_IMUStart();

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_IMUGetAcceleration([MarshalAs(UnmanagedType.LPArray, SizeConst=3)] float[] data);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_IMUGetGyro([MarshalAs(UnmanagedType.LPArray, SizeConst=3)] float[] data);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_IMUGetRotation([MarshalAs(UnmanagedType.LPArray, SizeConst=4)] float[] data);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_IMUGetMagneticField([MarshalAs(UnmanagedType.LPArray, SizeConst=3)] float[] data);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_IMUStop();

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_IMUGetRate(float[] rate);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_IMUGetDataFormat(int[] format, bool requested);

		// Position
		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_PositionMonitorStart();

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_PositionMonitorUpdate(float delay);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern void L7_PositionMonitorGetPosition([MarshalAs(UnmanagedType.LPArray, SizeConst=3)] float[] pos);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern void L7_PositionMonitorGetRotation([MarshalAs(UnmanagedType.LPArray, SizeConst=4)] float[] rot);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_PositionMonitorStop();

		//Camera settings
		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_CameraSetWhiteBalance(int value);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_CameraSetAutoWhiteBalanceEnabled(bool value);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_CameraIsAutoWhiteBalanceEnabled();

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_CameraSetExposure(int value);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_CameraSetAutoExposureEnabled(bool value);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		[return: MarshalAsAttribute(UnmanagedType.I1)]
		public static extern bool L7_CameraIsAutoExposureEnabled();

		// Rendering
		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void SetUnityColorRenderEventTextureID(System.IntPtr textureL7_andle);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void SetUnityThermalRenderEventTextureID(System.IntPtr textureL7_andle);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void SetUnityDepthRenderEventTextureID(System.IntPtr textureL7_andle, bool colorize);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void OnRenderEvent(int eventID);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern IntPtr GetRenderEventFunc();

		// System Info
		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetDeviceModel(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetDeviceMake(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetDeviceECVersion(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetDeviceOSVersion(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetDeviceISOVersion(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetDeviceKernelVersion(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetDeviceBiosVersion(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetDeviceBiosRevision(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetDeviceBiosReleaseDate(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetDeviceSerialNumber(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetHardwareVariant(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetAPIVersion(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetRuntimeVersion(string buffer);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetPlatform(int[] platform);

		[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
		public static extern void L7_GetAvailableDevices(int[] availableDevices, int count);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void L7_GetDisplayProjectionMatrices(float near, float far, [MarshalAs(UnmanagedType.LPArray, SizeConst = 16)] out Matrix4x4 matrixLeft, [MarshalAs(UnmanagedType.LPArray, SizeConst = 16)] out Matrix4x4 matrixRight);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void L7_GetDisplayPoses([MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] out Vector3 posLeft, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] out Quaternion rotLeft, [MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] out Vector3 posRight, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] out Quaternion rotRight);
    }
}
