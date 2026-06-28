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
            // Hardcoded input JPEG files to merge
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.jpg",
                @"C:\Images\input2.jpg",
                @"C:\Images\input3.jpg"
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

            // Hardcoded logo PNG path
            string logoPath = @"C:\Images\logo.png";
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            // Hardcoded output PNG path
            string outputPath = @"C:\Images\merged_with_logo.png";

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

            // Calculate canvas dimensions for horizontal stitching
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create PNG canvas bound to the output file
            Source fileSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = fileSource };
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

                // Load logo image
                using (RasterImage logo = (RasterImage)Image.Load(logoPath))
                {
                    // Determine bottom‑right position
                    int posX = canvas.Width - logo.Width;
                    int posY = canvas.Height - logo.Height;
                    if (posX < 0) posX = 0;
                    if (posY < 0) posY = 0;

                    // Draw logo onto canvas
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(logo, new Point(posX, posY));
                }

                // Save the final image (canvas is already bound to outputPath)
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
 * 1. When a marketing automation system needs to combine several product photos (JPEG) into a single banner and brand the result with a company logo (PNG) in the bottom‑right corner before publishing as a PNG file.
 * 2. When an e‑commerce platform generates a composite image of multiple item thumbnails and wants to embed a transparent PNG watermark logo at the corner to protect copyright before storing the final PNG.
 * 3. When a reporting tool stitches together scanned JPEG pages into one overview image and adds a corporate logo PNG at the lower‑right to identify the report source before exporting as PNG.
 * 4. When a social‑media scheduler creates a horizontal collage of event photos (JPEG) and automatically places a sponsor’s logo PNG in the bottom‑right to meet branding guidelines before uploading the PNG.
 * 5. When a digital signage application merges several advertisement JPEGs into a single slide and overlays a PNG logo at the corner to ensure consistent branding across all displayed PNG assets.
 */