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
            // Hardcoded input image paths (JPEG) and logo path (PNG)
            string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
            string logoPath = "logo.png";
            string outputPath = "output/merged.png";

            // Validate input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of input images
            var sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal stitching
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create output source and PNG options
            var source = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = source };

            // Create bound PNG canvas
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Merge input images horizontally onto the canvas
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Load logo image
                using (RasterImage logo = (RasterImage)Image.Load(logoPath))
                {
                    // Position logo at bottom‑right corner
                    int posX = canvas.Width - logo.Width;
                    int posY = canvas.Height - logo.Height;
                    var logoBounds = new Rectangle(posX, posY, logo.Width, logo.Height);
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
 * 1. When creating a product catalog PDF, a developer can merge multiple product JPEG photos side‑by‑side, overlay the company logo PNG in the bottom‑right corner, and save the result as a high‑quality PNG for further processing.
 * 2. When generating a social‑media collage, a C# service can stitch user‑uploaded JPEG images horizontally, add a brand watermark PNG at the lower‑right edge, and output a single PNG file for sharing.
 * 3. When building an e‑commerce thumbnail generator, the code can combine several JPEG view images of an item, place the store’s logo PNG on the bottom‑right of the merged canvas, and store the final PNG for fast web delivery.
 * 4. When automating a marketing email campaign, a developer can merge promotional JPEG banners, embed the corporate logo PNG at the corner, and export the composite as a PNG to embed in the email HTML.
 * 5. When preparing a printable brochure, the application can horizontally merge high‑resolution JPEG product shots, overlay the partner’s logo PNG in the bottom‑right, and save the combined image as a PNG for the layout designer.
 */