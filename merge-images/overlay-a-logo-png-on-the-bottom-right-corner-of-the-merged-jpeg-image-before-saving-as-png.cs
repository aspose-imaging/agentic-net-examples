// HOW-TO: Merge JPEG Images Horizontally And Add Logo Watermark In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input image paths (hardcoded)
            string[] inputPaths = new string[]
            {
                "image1.jpg",
                "image2.jpg"
            };
            string logoPath = "logo.png";
            string outputPath = "merged.png";

            // Validate input images
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Validate logo image
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of input images
            List<Aspose.Imaging.Size> sizeList = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizeList.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int canvasWidth = sizeList.Sum(s => s.Width);
            int canvasHeight = sizeList.Max(s => s.Height);

            // Create output source and PNG options
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outputSource };

            // Create canvas bound to output file
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Merge images horizontally
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

                // Load logo image
                using (RasterImage logo = (RasterImage)Image.Load(logoPath))
                {
                    int logoPosX = canvas.Width - logo.Width;
                    int logoPosY = canvas.Height - logo.Height;
                    Rectangle logoBounds = new Rectangle(logoPosX, logoPosY, logo.Width, logo.Height);
                    canvas.SaveArgb32Pixels(logoBounds, logo.LoadArgb32Pixels(logo.Bounds));
                }

                // Save the bound canvas
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
 * 1. When you need to combine product photos side‑by‑side and brand the result with a company logo before publishing online.
 * 2. When creating a single promotional banner from multiple JPEG ads and want the logo placed automatically at the bottom‑right corner.
 * 3. When generating a composite image for a PDF report that merges scanned pages and adds a confidential watermark logo.
 * 4. When building a web service that receives several JPEG uploads, stitches them together, and returns a PNG with a logo for brand consistency.
 * 5. When preparing images for an e‑commerce catalog where each merged photo must include a trademark logo in the corner to prevent unauthorized use.
 */
