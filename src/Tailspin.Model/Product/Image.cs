using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tailspin.Model {
    /// <summary>
    /// A class which represents a URL-based image
    /// </summary>
    [DataContract]
    public class Image {
        public Image() { }
        internal string _thumbnailPhoto;
        internal string _fullPhoto;
        public string ThumbnailPhoto { get { return _thumbnailPhoto + "-thumb.jpg"; } }
        public string FullSizePhoto { get { return _fullPhoto + "-cart.jpg"; } }

        public Image(string thumb, string full) {
            _thumbnailPhoto = thumb;
            _fullPhoto = full;
        }

    }
}
