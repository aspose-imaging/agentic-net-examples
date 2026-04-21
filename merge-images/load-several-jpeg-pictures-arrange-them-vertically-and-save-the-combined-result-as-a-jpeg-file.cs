using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string[] inputPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
        string outputPath = "combined.jpg";

        // Validate input files
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string inputPath in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(inputPath))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for vertical arrangement
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            if (sz.Width > canvasWidth) canvasWidth = sz.Width;
            canvasHeight += sz.Height;
        }

        // Create JPEG options with bound output source
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = outputSource,
            Quality = 100
        };

        // Create canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the bound canvas
            canvas.Save();
        }
    }
}