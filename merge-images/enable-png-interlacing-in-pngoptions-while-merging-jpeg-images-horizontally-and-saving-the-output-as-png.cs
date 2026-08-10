// HOW-TO: Merge Multiple JPEGs Horizontally into Interlaced PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG files
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hardcoded output PNG file
            string outputPath = "merged.png";

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

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create PNG options with interlacing (Progressive)
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions
            {
                Source = src,
                Progressive = true
            };

            // Create bound PNG canvas
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
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
 * 1. When you need to combine several JPEG product photos into a single progressive PNG for faster web page rendering.
 * 2. When generating a horizontal banner from multiple JPEG assets and want the PNG output to load progressively on browsers.
 * 3. When creating a sprite sheet of UI icons stored as JPEGs and require an interlaced PNG to reduce perceived loading time.
 * 4. When assembling scanned JPEG pages into a single PNG file that supports progressive display in email newsletters.
 * 5. When building a composite image for a PDF report where the final PNG must be interlaced for efficient streaming.
 */
