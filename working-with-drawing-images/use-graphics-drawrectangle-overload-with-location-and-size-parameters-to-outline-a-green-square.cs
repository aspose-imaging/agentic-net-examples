using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\green_square.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Create a green pen with a thickness of 2
                Pen greenPen = new Pen(Color.Green, 2);

                // Draw a green square at (150,150) with size 200x200
                graphics.DrawRectangle(greenPen, 150, 150, 200, 200);

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
 * 1. When generating a PNG report thumbnail that highlights a region of interest by drawing a green square with the Graphics.DrawRectangle overload (location and size) using Aspose.Imaging for .NET.
 * 2. When creating a custom UI overlay in a C# desktop application that outlines selected objects on a 500×500 canvas by calling Graphics.DrawRectangle with location and size parameters and a green Pen.
 * 3. When preprocessing images for a machine‑learning pipeline and need to annotate bounding boxes in green on PNG files by using the Graphics.DrawRectangle overload to draw a square at a specific coordinate.
 * 4. When building an automated testing tool that visualizes expected layout positions by drawing a green square with Graphics.DrawRectangle (location, size) on a generated image saved as PNG.
 * 5. When producing printable graphics where a green square serves as a marker for alignment or cropping, and the developer uses Aspose.Imaging’s Graphics.DrawRectangle overload to render the square in a 500×500 PNG image.
 */