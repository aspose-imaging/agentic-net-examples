using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Path where the resulting image will be saved.
        string outputPath = @"C:\temp\green_square.png";

        try
        {
            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream for the output image.
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set up PNG options with the stream as the source.
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a new 300x300 image.
                using (Image image = Image.Create(pngOptions, 300, 300))
                {
                    // Initialize graphics for drawing.
                    Graphics graphics = new Graphics(image);

                    // Define a green pen with a thickness of 3 pixels.
                    Pen greenPen = new Pen(Color.Green, 3);

                    // Draw a square at (50,50) with width and height of 200 pixels.
                    graphics.DrawRectangle(greenPen, 50, 50, 200, 200);

                    // Save the changes to the image.
                    image.Save();
                }
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
 * 1. When creating a PNG badge for a mobile app where a green square outlines the app’s logo to draw user attention.
 * 2. When generating a printable PDF report that includes a 300 × 300 image with a green square highlight to mark a region of interest.
 * 3. When building an automated testing tool that captures screenshots and draws a green rectangle around UI elements to verify layout accuracy.
 * 4. When developing a web service that returns a PNG image with a green square overlay to indicate a selected area on a map tile.
 * 5. When producing custom QR code graphics that require a green square border to separate the code from the background for branding purposes.
 */