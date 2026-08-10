// HOW-TO: Create BMP Image, Draw Ellipse, Reset Graphics Transform in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output BMP file path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and bind to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image with the specified options
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a background color
                graphics.Clear(Color.Wheat);

                // Draw an ellipse using a blue pen
                Pen ellipsePen = new Pen(Color.Blue, 3);
                Rectangle ellipseBounds = new Rectangle(100, 100, 300, 200);
                graphics.DrawEllipse(ellipsePen, ellipseBounds);

                // Reset any transformations applied to the graphics object
                graphics.ResetTransform();

                // Save the image (output is already bound to the file)
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
 * 1. When you need to generate a 24‑bit BMP file with a custom‑drawn ellipse for a report thumbnail.
 * 2. When you want to programmatically create a blank canvas, draw shapes, and ensure subsequent drawing starts from the default coordinate system.
 * 3. When you are building a server‑side image generation service that must output BMP images with precise dimensions and background colors.
 * 4. When you need to reset any applied transformations before adding more graphics to avoid cumulative scaling or rotation effects.
 * 5. When you are automating the creation of simple diagram elements such as ellipses for UI assets without using external design tools.
 */
