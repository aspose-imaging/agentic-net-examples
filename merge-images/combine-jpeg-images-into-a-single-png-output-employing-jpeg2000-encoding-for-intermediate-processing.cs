using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files (hardcoded)
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Output PNG file (hardcoded)
        string outputPath = "output.png";

        // Validate input files
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
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                canvasWidth += img.Width;
                if (img.Height > canvasHeight)
                    canvasHeight = img.Height;
            }
        }

        // Create PNG canvas with bound output source
        Source outputSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions { Source = outputSource };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                // Load JPEG as raster
                using (RasterImage jpegRaster = (RasterImage)Image.Load(path))
                {
                    // Convert to JPEG2000 intermediate
                    using (Jpeg2000Image jp2Image = new Jpeg2000Image(jpegRaster))
                    {
                        // Copy pixels onto canvas
                        var bounds = new Rectangle(offsetX, 0, jp2Image.Width, jp2Image.Height);
                        canvas.SaveArgb32Pixels(bounds, jp2Image.LoadArgb32Pixels(jp2Image.Bounds));
                        offsetX += jp2Image.Width;
                    }
                }
            }

            // Save the bound canvas (output PNG)
            canvas.Save();
        }
    }
}