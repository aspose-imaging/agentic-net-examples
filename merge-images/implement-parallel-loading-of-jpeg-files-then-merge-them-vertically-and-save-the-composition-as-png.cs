// HOW-TO: Merge Multiple JPEG Images Vertically Into a PNG Using Parallel Loading in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input JPEG file paths
            string[] inputPaths = new string[]
            {
                "Input\\image1.jpg",
                "Input\\image2.jpg",
                "Input\\image3.jpg"
            };

            // Hardcoded output PNG path
            string outputPath = "Output\\merged.png";

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

            // Parallel loading to collect image sizes
            List<Size> sizes = new List<Size>();
            object lockObj = new object();

            inputPaths.AsParallel().ForAll(path =>
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    lock (lockObj)
                    {
                        sizes.Add(img.Size);
                    }
                }
            });

            // Calculate canvas dimensions for vertical merge
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Create PNG canvas bound to the output file
            Source source = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = source };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }
                // Save the bound image
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
 * 1. When you need to combine several scanned JPEG pages into a single PNG document for easier viewing or printing.
 * 2. When building a web service that creates a tall image sprite from user‑uploaded JPEGs to improve page load performance.
 * 3. When generating a printable PDF cover sheet by first stitching JPEG photos vertically and then converting to PNG for lossless quality.
 * 4. When processing large batches of product photos in parallel to reduce memory usage and speed up creation of a composite PNG catalog.
 * 5. When creating a timeline graphic where each event’s JPEG picture is stacked vertically and saved as a high‑resolution PNG for sharing.
 */
