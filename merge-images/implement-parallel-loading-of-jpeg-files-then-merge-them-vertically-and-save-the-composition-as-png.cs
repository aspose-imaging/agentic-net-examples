// HOW-TO: Merge Multiple JPEG Images Vertically Into a PNG Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDirectory = "InputImages";
            string outputPath = "Output/merged.png";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get JPEG files
            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Load images in parallel and collect pixel data
            var imageDataList = files.AsParallel()
                .Select(path =>
                {
                    if (!File.Exists(path))
                    {
                        Console.Error.WriteLine($"File not found: {path}");
                        return null;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        var bounds = img.Bounds;
                        int[] pixels = img.LoadArgb32Pixels(bounds);
                        return new
                        {
                            Width = img.Width,
                            Height = img.Height,
                            Pixels = pixels
                        };
                    }
                })
                .Where(x => x != null)
                .ToList();

            if (imageDataList.Count == 0)
            {
                Console.WriteLine("No valid images were loaded.");
                return;
            }

            // Calculate canvas size for vertical merge
            int canvasWidth = imageDataList.Max(i => i.Width);
            int canvasHeight = imageDataList.Sum(i => i.Height);

            // Create PNG canvas bound to output file
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outputSource };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (var data in imageDataList)
                {
                    var destRect = new Rectangle(0, offsetY, data.Width, data.Height);
                    canvas.SaveArgb32Pixels(destRect, data.Pixels);
                    offsetY += data.Height;
                }

                // Save the composed image
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
 * 1. When you need to combine a series of scanned JPEG pages into a single PNG document for easier viewing or printing.
 * 2. When building a web service that creates a vertical thumbnail strip from user‑uploaded JPEG photos on the fly.
 * 3. When generating a composite image for a product catalog by stitching product JPEG shots together into one high‑resolution PNG.
 * 4. When processing large batches of JPEG files in parallel to reduce load time before creating a combined PNG for archival.
 * 5. When creating a vertical sprite sheet from individual JPEG assets for use in game development or UI design.
 */
