using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"c:\temp\concentric.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Parameters for concentric ellipses
                int centerX = 250;
                int centerY = 250;
                int maxRadius = 200;
                int step = 20;
                bool useRed = true;

                // Draw ellipses with alternating colors
                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    Aspose.Imaging.Color ellipseColor = useRed ? Aspose.Imaging.Color.Red : Aspose.Imaging.Color.Blue;
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(ellipseColor, 2);

                    int left = centerX - radius;
                    int top = centerY - radius;
                    int diameter = radius * 2;

                    graphics.DrawEllipse(pen, left, top, diameter, diameter);
                    useRed = !useRed;
                }

                // Save the image
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
 * 1. When generating a simple BMP placeholder image for UI testing, a developer can use this C# Aspose.Imaging code to draw concentric ellipses with alternating red and blue outlines.
 * 2. When creating custom chart backgrounds or radar‑style graphics in a .NET desktop application, the code provides a quick way to render layered ellipses onto a 24‑bit BMP canvas.
 * 3. When producing printable pattern samples for a design‑to‑manufacturing workflow, the example shows how to programmatically generate a BMP file with precise ellipse spacing using Aspose.Imaging.Graphics.
 * 4. When automating the generation of diagnostic visual markers for image‑processing pipelines, this snippet creates a BMP image with concentric circles that can be overlaid on test frames.
 * 5. When building a lightweight C# utility that needs to export vector‑style shapes as a BMP file for legacy systems, the code demonstrates how to draw alternating‑color ellipses with a Pen object.
 */