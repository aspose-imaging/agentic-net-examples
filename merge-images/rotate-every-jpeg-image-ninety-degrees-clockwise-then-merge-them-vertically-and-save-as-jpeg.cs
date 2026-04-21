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
        // Hardcoded input JPEG file paths
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Hardcoded output path
        string outputPath = "merged.jpg";

        // Validate each input file exists
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

        // First pass: load each image, rotate, and collect its size
        List<Size> sizes = new List<Size>();
        foreach (string inputPath in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(inputPath))
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                sizes.Add(new Size(img.Width, img.Height));
            }
        }

        // Calculate canvas dimensions for vertical merge
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Sum(s => s.Height);

        // Create output JPEG canvas bound to the output file
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = outputSource,
            Quality = 90
        };

        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;

            // Second pass: load, rotate, and copy each image onto the canvas
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the bound canvas (output file is already specified in options)
            canvas.Save();
        }
    }
}