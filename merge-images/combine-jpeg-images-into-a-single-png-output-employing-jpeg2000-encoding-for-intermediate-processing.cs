using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG image paths
        string[] inputPaths = new string[]
        {
            @"C:\images\img1.jpg",
            @"C:\images\img2.jpg",
            @"C:\images\img3.jpg"
        };

        // Hardcoded output PNG path
        string outputPath = @"C:\images\merged.png";

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Determine canvas size (horizontal stitching)
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                totalWidth += img.Width;
                if (img.Height > maxHeight)
                    maxHeight = img.Height;
            }
        }

        // Create PNG options with bound output source
        Source fileSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = fileSource };

        // Create a blank canvas for the merged image
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;

            // Process each JPEG image
            foreach (string path in inputPaths)
            {
                // Load JPEG as raster image
                using (RasterImage jpegImg = (RasterImage)Image.Load(path))
                {
                    // Convert to JPEG2000 intermediate (encodes using JPEG2000)
                    using (Jpeg2000Image jp2Img = new Jpeg2000Image(jpegImg))
                    {
                        // Copy pixels from the JPEG2000 image onto the canvas
                        Rectangle bounds = new Rectangle(offsetX, 0, jp2Img.Width, jp2Img.Height);
                        canvas.SaveArgb32Pixels(bounds, jp2Img.LoadArgb32Pixels(jp2Img.Bounds));

                        // Update horizontal offset
                        offsetX += jp2Img.Width;
                    }
                }
            }

            // Save the bound canvas to the output PNG file
            canvas.Save();
        }
    }
}