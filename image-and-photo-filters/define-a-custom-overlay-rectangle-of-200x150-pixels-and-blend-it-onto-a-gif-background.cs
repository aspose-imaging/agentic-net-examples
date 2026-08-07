using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the background GIF as a raster image
            using (RasterImage background = (RasterImage)Image.Load(inputPath))
            {
                // Create an overlay rectangle image (200x150)
                using (var overlayStream = new MemoryStream())
                {
                    Source overlaySource = new StreamSource(overlayStream);
                    PngOptions overlayOptions = new PngOptions() { Source = overlaySource };
                    using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, 200, 150))
                    {
                        // Draw a semi‑transparent red rectangle onto the overlay
                        Graphics graphics = new Graphics(overlay);
                        SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Red));
                        graphics.FillRectangle(brush, new Rectangle(0, 0, 200, 150));

                        // Blend the overlay onto the background at position (50,50) with 50% opacity
                        background.Blend(new Point(50, 50), overlay, 128);
                    }
                }

                // Save the resulting image as GIF
                GifOptions gifOptions = new GifOptions()
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                background.Save(outputPath, gifOptions);
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
 * 1. When a developer wants to add a semi‑transparent promotional banner to an animated GIF for email marketing, they can use this code to draw a 200×150 red overlay and blend it onto the background.
 * 2. When building a web service that watermarks user‑uploaded GIFs with a custom logo rectangle, the snippet shows how to create the overlay in memory and merge it at a specific position.
 * 3. When generating dynamic GIF thumbnails with a colored call‑to‑action area, this example demonstrates blending a 200×150 rectangle onto the original animation using Aspose.Imaging for .NET.
 * 4. When creating an automated report that highlights a region of interest in a GIF by overlaying a translucent rectangle, the code provides the exact steps to draw and blend the overlay.
 * 5. When integrating GIF editing into a desktop application that needs to apply a semi‑transparent red filter to a defined area, this sample illustrates loading the GIF, creating the overlay, and saving the result.
 */