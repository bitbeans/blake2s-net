using System;
using System.Linq;

namespace Tests
{
    public static class TestHelper
    {
        /// <summary>
        ///     Simple Hex to byte array converter.
        /// </summary>
        /// <param name="hex">A valid hex string.</param>
        /// <see cref="http://stackoverflow.com/a/321404/1837988"/>
        /// <returns>A byte array.</returns>
        public static byte[] StringToByteArray(string hex)
        {
            if (!string.IsNullOrEmpty(hex))
            {
                return Enumerable.Range(0, hex.Length)
                    .Where(x => x%2 == 0)
                    .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                    .ToArray();
            }
            return (byte[])null;
        }
    }
}