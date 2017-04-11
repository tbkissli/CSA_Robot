using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTestat1
{
    /// <summary>
    /// EventArgs-Klasse um über Änderungen der Länge und Breite des gemessenen Objekts zu informieren.
    /// </summary>
    class ObjectParametersEventArgs : EventArgs
    {
        #region constructor & destructor
        /// <summary>
        /// Initialisiert die ObjectParametersEventArgs-Klasse
        /// </summary>
        public ObjectParametersEventArgs(float lengthObject, float widthObject)
        {
            LengthObject = lengthObject;
            WidthObject = widthObject;
        }
        #endregion

        #region properties
        /// <summary>
        /// Liefert bzw. setzt die Länge des Objekts
        /// </summary>
        public float LengthObject { get; set; }


        /// <summary>
        /// Liefert bzw. setzt die Breite des Objekts
        /// </summary>
        public float WidthObject { get; set; }
        #endregion
    }
}
