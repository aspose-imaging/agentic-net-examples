using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG file paths
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
            // Hardcoded output PNG file path
            string outputPath = "merged.png";

            // Validate each input file exists
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Prepare PNG creation options with bound output source
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = src };

            // Create the output canvas
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                // Merge each JPEG onto the canvas side by side
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                // Save the bound canvas (output path already set in source)
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
 * 1. When creating a product catalog thumbnail that combines multiple JPEG photos side by side into a single PNG for web display.
 * 2. When generating a before‑and‑after comparison image by stitching two JPEG shots horizontally and exporting the result as a lossless PNG for documentation.
 * 3. When building a photo‑strip collage for a social‑media post where several JPEG snapshots need to be merged into one PNG banner using C# and Aspose.Imaging.
 * 4. When preparing a printable proof sheet that aligns several JPEG scans on a single canvas and saves it as a high‑resolution PNG for quality control.
 * 5. When developing an automated report that assembles chart images captured as JPEGs into a single side‑by‑side PNG diagram for inclusion in PDF reports.
 */