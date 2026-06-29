using System;
using System.IO;
using System.Collections.Generic;
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
            string[] inputPaths = new[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            // Validate each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Hardcoded output PNG path
            string outputPath = "merged.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

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
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight)
                    canvasHeight = sz.Height;
            }

            // Create PNG canvas with bound output source
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                        canvas.SaveArgb32Pixels(bounds, pixels);
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas (output path already set in options)
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
 * 1. When a developer needs to generate a single PNG banner that combines multiple product photos stored as JPEG files for an e‑commerce website, they can use this code to stitch the images side by side.
 * 2. When creating a printable PDF report that requires a composite image of several scanned JPEG pages displayed horizontally, the code merges them into a high‑quality PNG canvas before embedding.
 * 3. When building a photo‑gallery slideshow where thumbnail previews are composed from several JPEG thumbnails into one PNG strip, this routine assembles the thumbnails in a single row.
 * 4. When an automated marketing tool must combine customer‑uploaded JPEG logos into a single PNG header image for email campaigns, the code provides a fast C# solution using Aspose.Imaging.
 * 5. When a desktop application needs to compare visual differences by placing original JPEG screenshots next to each other in a PNG layout, the code creates the side‑by‑side composition for analysis.
 */