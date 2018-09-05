using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFMediaKit.DirectShow.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;


namespace RIS.Control
{
    public class VideoCaptureExtend : VideoCaptureElement
    {
        public System.Windows.Controls.Image VideoImageE
        {
            get
            {
                return this.VideoImage;
            }
        }
        protected override void  OnMediaPlayerNewAllocatorSurface(IntPtr pSurface)
        {
            //base.OnMediaPlayerNewAllocatorSurface(pSurface);
            //var drawingVisual = new DrawingVisual();
            ////创建RenderTargetBitmap
            //var rtbitmap = new RenderTargetBitmap((int)VideoImageE.Width,
            //    (int)VideoImageE.Height,
            //    96,
            //    96,
            //    PixelFormats.Default);
            //using (var dc = drawingVisual.RenderOpen())
            //{
            //    dc.DrawImage(VideoImageE.Source, new Rect(0, 0, VideoImageE.Width, VideoImageE.Height));
            //    dc.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Red, 2), new Rect(10, 10, 100,100));
            //    rtbitmap.Render(drawingVisual);
            //    this.VideoImageE.Source = rtbitmap;
                
            //}
        }

    }
}
