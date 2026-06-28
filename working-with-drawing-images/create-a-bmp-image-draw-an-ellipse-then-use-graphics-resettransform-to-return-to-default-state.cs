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
            // Output BMP file path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a background color
                graphics.Clear(Color.Wheat);

                // Draw an ellipse with a blue pen
                Pen pen = new Pen(Color.Blue, 2);
                graphics.DrawEllipse(pen, new Rectangle(100, 100, 300, 200));

                // Reset any transformations applied to the graphics object
                graphics.ResetTransform();

                // Save the image to the specified path
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
 * 1. When a developer needs to generate a simple 24‑bit BMP thumbnail with a highlighted elliptical region for a legacy Windows application that only supports BMP files.
 * 2. When a reporting tool must programmatically add a blue ellipse overlay to a 500×500 bitmap chart and then revert the graphics state before drawing additional elements.
 * 3. When an automated testing framework creates a BMP image to verify that Graphics.ResetTransform correctly restores the default coordinate system after applying custom transformations.
 * 4. When a desktop utility produces a BMP placeholder image with a wheat‑colored background and a centered ellipse for use in UI mockups that require exact pixel dimensions.
 * 5. When a batch image‑processing script needs to draw a geometric shape on a BMP canvas and ensure subsequent drawing commands start from the original origin without residual transforms.
 */