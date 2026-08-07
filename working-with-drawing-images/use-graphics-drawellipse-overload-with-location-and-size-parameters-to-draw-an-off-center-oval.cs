using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded output path
        string outputPath = @"C:\temp\offcenter_oval.png";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with the output file as the source
            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                var graphics = new Graphics(image);

                // Fill background
                graphics.Clear(Color.Wheat);

                // Pen for the ellipse
                var pen = new Pen(Color.Blue, 3);

                // Draw an off‑center oval (ellipse) using location and size parameters
                // x = 150, y = 100, width = 200, height = 100
                graphics.DrawEllipse(pen, 150, 100, 200, 100);

                // Save the image (already linked to outputPath via options)
                image.Save();
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
 * 1. When a developer needs to generate a PNG report thumbnail that highlights an off‑center oval annotation on a 500×500 canvas using Aspose.Imaging’s Graphics.DrawEllipse overload.
 * 2. When building a C# web service that creates custom badge images with a blue ellipse positioned away from the center to indicate a status region.
 * 3. When automating the production of marketing assets where a wheat‑colored background and a displaced oval are required for branding consistency in PNG files.
 * 4. When implementing a desktop application that visualizes sensor coverage areas as off‑center ellipses on a fixed‑size image for engineering analysis.
 * 5. When creating test images for image‑processing pipelines that need a known ellipse location and size to validate detection algorithms in .NET.
 */