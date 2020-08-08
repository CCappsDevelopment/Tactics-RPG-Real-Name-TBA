using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

// BEGIN RectangleExtensions.cs
namespace TacticsRPG_WorldEditor.Extensions
{
    /// <summary>
    /// RectangleExtensions static class
    /// Extension class for adding Scaling functionality
    /// to Rectangle objects.
    /// </summary>
    static class RectangleExtensions
    {
        /// <summary>
        /// Scale(this Rectangle, float)
        /// Extension method to Scale a Rectangle object by the given factor.
        /// </summary>
        /// <param name="rect">(Rectangle) - The Rectangle to be scaled.</param>
        /// <param name="factor">(float) - The factor by which to scale the Rectangle</param>
        /// <returns>Rectangle - Scaled Rectangle object</returns>
        public static Rectangle Scale(this Rectangle rect, float factor)
        {
            // Scale the Rectangle by the given factor, return new Rectangle
            return new Rectangle(
                Convert.ToInt32(rect.X * factor),
                Convert.ToInt32(rect.Y * factor),
                Convert.ToInt32(rect.Width * factor),
                Convert.ToInt32(rect.Height * factor)
            );
        }
    }
}
// END RectangleExtensions.cs
