// HOW-TO: Rotate JPEG Images 90 Degrees Clockwise and Merge Vertically in C# (Aspose.Imaging for .NET)
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
        try
        {
            // Hardcoded input JPEG files
            string[] inputPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
            // Hardcoded output file
            string outputPath = "merged.jpg";

            // Validate each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // First pass: determine canvas size after rotating each image 90° clockwise
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (var inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    sizes.Add(img.Size);
                }
            }

            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Prepare JPEG options with bound output source
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            // Create a JPEG canvas with the calculated dimensions
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                // Second pass: load, rotate, and copy each image onto the canvas vertically
                foreach (var inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the bound canvas (output file)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you have a batch of JPEG photos saved sideways and need to rotate each 90° clockwise and stack them vertically into one high‑quality JPEG using Aspose.Imaging for .NET.
 * 2. When generating a single receipt image by rotating individual scanned JPEG pages and merging them vertically with Aspose.Imaging in a C# application.
 * 3. When creating a continuous banner from separate JPEG panels that must be rotated to the correct orientation and combined into one tall JPEG via Aspose.Imaging.
 * 4. When preparing a printable collage of portrait‑style JPEGs that were scanned upside‑down, requiring a 90° clockwise rotation and vertical merge with Aspose.Imaging for .NET.
 * 5. When automating the production of a single JPEG sprite sheet from multiple rotated icons for a game UI using C# and Aspose.Imaging.
 */
