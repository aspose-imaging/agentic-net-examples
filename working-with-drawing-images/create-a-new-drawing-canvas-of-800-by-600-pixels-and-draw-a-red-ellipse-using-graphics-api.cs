using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\ellipse.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options (no source needed for creating a new image)
            var pngOptions = new PngOptions();

            // Create a new image with the desired canvas size (800x600)
            using (Image image = Image.Create(pngOptions, 800, 600))
            {
                // Initialize graphics object for drawing
                var graphics = new Graphics(image);

                // Optional: clear the canvas with a background color
                graphics.Clear(Color.White);

                // Define a red pen with a thickness of 2 pixels
                var redPen = new Pen(Color.Red, 2);

                // Draw an ellipse bounded by the specified rectangle
                // Rectangle(x, y, width, height)
                graphics.DrawEllipse(redPen, new Rectangle(100, 100, 600, 400));

                // Save the image to the output path
                image.Save(outputPath);
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
 * 1. When generating a PNG placeholder image with a red ellipse on an 800 × 600 canvas for web UI mockups.
 * 2. When creating a custom report background in C# that requires an 800 × 600 drawing surface with a red ellipse overlay using Aspose.Imaging.
 * 3. When automating the production of printable marketing flyers that need a white PNG canvas with a centered red ellipse drawn via the graphics API.
 * 4. When developing a game asset pipeline that programmatically draws a red ellipse onto texture files to visualize hit‑area boundaries.
 * 5. When building a diagnostic tool that saves a PNG screenshot with a highlighted red ellipse to indicate a region of interest.
 */