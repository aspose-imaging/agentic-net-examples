using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Graphics;

class MergeImagesVertical
{
    static void Main()
    {
        // Input JPEG files to merge (modify paths as needed)
        string[] inputFiles = {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Load all source images as RasterImage objects
        List<RasterImage> sources = new List<RasterImage>();
        int maxWidth = 0;
        int totalHeight = 0;

        foreach (string file in inputFiles)
        {
            // Load image using the generic Image.Load method (lifecycle rule)
            Image img = Image.Load(file);
            // Cast to RasterImage for pixel access
            RasterImage raster = (RasterImage)img;
            sources.Add(raster);

            // Determine combined dimensions
            if (raster.Width > maxWidth) maxWidth = raster.Width;
            totalHeight += raster.Height;
        }

        // Create a new JPEG image with the calculated dimensions
        // Using the JpegImage(int, int) constructor (lifecycle rule)
        using (JpegImage merged = new JpegImage(maxWidth, totalHeight))
        {
            // Prepare graphics object for drawing
            using (Graphics graphics = new Graphics(merged))
            {
                int currentY = 0;
                foreach (RasterImage src in sources)
                {
                    // Draw each source image at the current vertical offset
                    graphics.DrawImage(src, new Rectangle(0, currentY, src.Width, src.Height));
                    currentY += src.Height;
                }
            }

            // Save the merged image as JPEG (lifecycle rule)
            string outputPath = @"C:\Images\merged_output.jpg";
            merged.Save(outputPath);
        }

        // Dispose source images
        foreach (RasterImage src in sources)
        {
            src.Dispose();
        }

        Console.WriteLine("Images merged successfully.");
    }
}