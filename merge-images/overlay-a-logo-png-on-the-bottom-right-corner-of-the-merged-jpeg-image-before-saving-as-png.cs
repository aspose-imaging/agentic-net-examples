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
            // Hardcoded input and output paths
            string[] inputPaths = { "input1.jpg", "input2.jpg" };
            string logoPath = "logo.png";
            string outputPath = "output/merged.png";

            // Validate input files
            foreach (string path in inputPaths)
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
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight) canvasHeight = sz.Height;
            }

            // Create bound PNG canvas
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = src };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Merge input images side by side
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

                // Overlay logo at bottom‑right corner
                using (RasterImage logo = (RasterImage)Image.Load(logoPath))
                {
                    int posX = canvas.Width - logo.Width;
                    int posY = canvas.Height - logo.Height;
                    Rectangle logoBounds = new Rectangle(posX, posY, logo.Width, logo.Height);
                    canvas.SaveArgb32Pixels(logoBounds, logo.LoadArgb32Pixels(logo.Bounds));
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
 * 1. When a developer needs to create a product catalog thumbnail by stitching multiple JPEG photos side‑by‑side and adding the company’s PNG logo in the bottom‑right corner before exporting as a PNG for web display.
 * 2. When an e‑commerce platform wants to generate promotional banners that combine several JPEG advertisements into one image and brand them with a transparent PNG logo overlay at the lower‑right edge.
 * 3. When a photo‑sharing app must merge user‑uploaded JPEG snapshots into a single collage and automatically watermark the collage with a PNG logo positioned at the bottom‑right before saving as PNG for sharing.
 * 4. When a marketing automation script prepares email newsletters by concatenating multiple JPEG images of offers and appends the corporate PNG logo in the bottom‑right corner to ensure brand consistency in the final PNG attachment.
 * 5. When a digital signage system assembles multiple JPEG slides into one widescreen image and overlays a transparent PNG sponsor logo at the bottom‑right before rendering the output as a PNG file for display.
 */