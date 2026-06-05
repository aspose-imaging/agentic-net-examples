using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
            // Hardcoded input and output paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            string outputPath = "output/output.jpg";

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect image sizes
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions with 10‑pixel padding between images
            int padding = 10;
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height) + padding * (sizes.Count - 1);

            // Create output JPEG canvas
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height + padding;
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
 * 1. When creating a printable photo collage in a C# web application, a developer can use this code to vertically merge multiple JPEGs with a 10‑pixel padding to keep each picture visually separated.
 * 2. When generating a product catalog PDF from individual product photos, a developer can stack JPEG images with a 10‑pixel gap to improve readability before converting the canvas to PDF.
 * 3. When building an automated email newsletter that includes a vertical timeline of event screenshots, a developer can merge the JPEG screenshots with a 10‑pixel separator to avoid image crowding.
 * 4. When preparing a series of scanned receipts for archival storage, a developer can combine the JPEG scans into one file with a 10‑pixel padding to make each receipt distinct for later review.
 * 5. When developing a desktop utility that creates a single JPEG sprite sheet from multiple icons, a developer can apply a 10‑pixel vertical padding to ensure each icon is easily selectable in UI design tools.
 */