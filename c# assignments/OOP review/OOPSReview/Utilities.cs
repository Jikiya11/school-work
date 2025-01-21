using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSReview
{
    public static class Utilities
    {
        /// <summary>
        /// Checks if our double value is positive
        /// 0.0 is assumed positive
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns></returns>
        public static bool IsPositive(double value)
        {
            // Alternative method
            /*
            if (value >= 0.0)
            {
                return true;
            }
            return false;
            */

            // Alternative method
            /*
            bool valid = false;
            if (value >= 0.0)
            {
                valid = true;
            }
            return valid;
            */

            return value >= 0.0;
        }

        /// <summary>
        /// Checks if our int value is positive
        /// 0 is assumed positive
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns></returns>
        public static bool IsPositive(int value) => value >= 0;

        /// <summary>
        /// Checks if our decimal value is positive
        /// 0.0m is assumed positive
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns></returns>
        public static bool IsPositive(decimal value) => value >= 0.0m;
    }
}
