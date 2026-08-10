// HOW-TO: Merge Multiple PNG Images Horizontally with Error Handling in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string[] inputPaths = new string[] { "input1.png", "input2.png", "input3.png" };
        string outputPath = "output.png";

        try
        {
            // Verify each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
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

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Prepare output file source and PNG options
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = src };

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create canvas image
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                // Merge each image onto the canvas
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                // Save the merged image (canvas is already bound to output path)
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
 * 1. When you need to combine several product photos into a single wide PNG for a web banner while safely handling missing or locked files.
 * 2. When an automated report generator must stitch chart images side‑by‑side into one image and ensure the process doesn’t crash if an input file is unavailable.
 * 3. When a desktop application creates a composite sprite sheet from individual PNG assets and must gracefully handle file‑access errors during loading.
 * 4. When a batch‑processing script merges scanned page images into a panoramic view and needs to verify each file exists before creating the output PNG.
 * 5. When a CI/CD pipeline assembles UI screenshots into a single image for documentation and requires robust exception handling to avoid pipeline failures.
 */
