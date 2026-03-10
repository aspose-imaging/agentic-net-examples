using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input JPG files to merge
            string[] inputFiles = new string[]
            {
                @"C:\Images\image1.jpg",
                @"C:\Images\image2.jpg",
                @"C:\Images\image3.jpg"
            };

            // Output WMF file
            string outputFile = @"C:\Images\merged.wmf";

            // Collect sizes
            List<Size> sizes = new List<Size>();
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (Size sz in sizes)
            {
                totalWidth += sz.Width;
                if (sz.Height > maxHeight) maxHeight = sz.Height;
            }

            // Create source for WMF output
            Source source = new FileCreateSource(outputFile, false);
            WmfOptions wmfOptions = new WmfOptions() { Source = source };

            // Create WMF recorder graphics (no using block as per rules)
            Rectangle canvasRect = new Rectangle(0, 0, totalWidth, maxHeight);
            int dpi = 96;
            WmfRecorderGraphics2D graphics = new WmfRecorderGraphics2D(canvasRect, dpi);

            // Draw each JPG onto the WMF canvas
            int offsetX = 0;
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                    Rectangle srcRect = new Rectangle(0, 0, img.Width, img.Height);
                    graphics.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
                    offsetX += img.Width;
                }
            }

            // Finalize WMF image and save
            using (WmfImage wmfImage = graphics.EndRecording())
            {
                wmfImage.Save(outputFile, wmfOptions);
            }
        }
    }
}