using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public static class Utilities
    {
        /// <summary>
        /// Checks to see if value is a non-zero positive number
        /// </summary>
        /// <param name="value">int value</param>
        /// <returns>Bool depending on result</returns>
        public static bool IsPositiveNonZero(int value)
        {
            return value > 0;
        }

        /// <summary>
        /// Checks to see if value is divisble by 100
        /// </summary>
        /// <param name="value">int value</param>
        /// <returns>Bool depending on result</returns>
        public static bool InHundreds(int value)
        {
            return value % 100 == 0;
        }
    }
}
