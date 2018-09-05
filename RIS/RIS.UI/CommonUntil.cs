using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace RIS
{
    public class CommonUntil
    {
        public static byte[] GetByteFromBitmap(Bitmap b)
        {
            MemoryStream ms = new MemoryStream();
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.ToArray();
            ms.Close();
            return bytes;
        }
        public static Bitmap GetBitmapFromBytes(byte[] bytes)
        {
            MemoryStream ms1 = new MemoryStream(bytes);
            
            Bitmap bm = (Bitmap)Image.FromStream(ms1);
            ms1.Flush();
            return bm;
            
        }
    }
}
