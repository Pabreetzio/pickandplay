using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public class Length : IEquatable<Length>
    {
        public double Millimeters { get; set; }
        public Length(double millimeters)
        {
            Millimeters = millimeters;
        }
        public double Meters
        {
            get
            {
                return Millimeters / 1000;
            }
            set
            {
                Millimeters = value * 1000;
            }
        }
        private const double millimeterToInchConversionFactor = 0.0393701;
        public double Inches
        {
            get
            {
                return Millimeters * millimeterToInchConversionFactor;
            }
            set
            {
                Millimeters = value / millimeterToInchConversionFactor;
            }
        }
        #region addition operators
        public static Length operator +(Length l1, Length l2)
        {
            return new Length(l1.Millimeters+l2.Millimeters);
        }
        public static Length operator +(Length l1, double l2)
        {
            return new Length(l1.Millimeters + l2);
        }
        public static Length operator +(double l2, Length l1)
        {
            return new Length(l1.Millimeters + l2);
        }
        #endregion
        #region division operators
        public static Length operator /(Length l1, Length l2)
        {
            return new Length(l1.Millimeters / l2.Millimeters);
        }
        public static Length operator /(Length l1, double l2)
        {
            return new Length(l1.Millimeters / l2);
        }
        public static Length operator /(double l2, Length l1)
        {
            return new Length(l2 / l1.Millimeters);
        }
        #endregion
        #region multiplication operators
        public static Length operator *(Length l1, Length l2)
        {
            return new Length(l1.Millimeters * l2.Millimeters);
        }
        public static Length operator *(Length l1, double l2)
        {
            return new Length(l1.Millimeters * l2);
        }
        public static Length operator *(double l2, Length l1)
        {
            return new Length(l1.Millimeters * l2);
        }
        #endregion
        #region subtractions operators
        public static Length operator -(Length l1, Length l2)
        {
            return new Length(l1.Millimeters - l2.Millimeters);
        }
        public static Length operator -(Length l1, double l2)
        {
            return new Length(l1.Millimeters - l2);
        }
        public static Length operator -(double l2, Length l1)
        {
            return new Length(l2 - l1.Millimeters);
        }
        #endregion

        #region equals
        bool IEquatable<Length>.Equals(Length other)
        {
            return other.Millimeters == this.Millimeters;
        }
        public override bool Equals(object obj)
        {
            return obj is Length && (obj as Length).Millimeters == Millimeters;
        }
        #endregion
    }
}
