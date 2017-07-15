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
 *     File Purpose:        Adds functionality to comparable objects.                                                                   *
 *                                                                                                                                      *
 *     Guide:                                                                                                                           *
 *                                                                                                                                      *
 ****************************************************************************************************************************************/

using System;

namespace DAQRI {

    public static class ComparisonExtensions {

        /// <summary>
        /// Finds the restricted value between a minimum and maximum.
        /// This does not alter the receiver.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <param name="min">The minimum allowed value.</param>
        public static T GetClampedValue<T> (this T value, T min, T max) where T : System.IComparable<T> {
            T result = value;

            if (value.CompareTo (max) > 0) {
                result = max;

            } else if (value.CompareTo (min) < 0) {
                result = min;
            }

            return result;
        }
    }
}
