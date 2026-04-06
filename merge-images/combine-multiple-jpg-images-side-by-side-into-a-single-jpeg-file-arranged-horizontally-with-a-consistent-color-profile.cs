using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input JPEG files (modify as needed)
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hard‑coded output JPEG file
        string outputPath = "output.jpg";

        // Validate each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int totalWidth = sizes.Sum(s => s.Width);
        int maxHeight = sizes.Max(s => s.Height);

        // Prepare JPEG options with a consistent color profile (default RGB) and bind to output file
        Source src = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = src,
            Quality = 100 // highest quality
        };

        // Create the output JPEG canvas
        using (JpegImage canvas = new JpegImage(jpegOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Define where the current image will be placed on the canvas
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);

                    // Copy pixel data onto the canvas
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));

                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (source already set)
            canvas.Save();
        }
    }
}