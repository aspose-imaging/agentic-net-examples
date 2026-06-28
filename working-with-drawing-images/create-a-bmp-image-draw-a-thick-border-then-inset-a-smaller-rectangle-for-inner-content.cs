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
            string outputPath = @"output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions
            int width = 400;
            int height = 300;

            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a thick outer border
                Pen outerPen = new Pen(Color.Black, 10);
                graphics.DrawRectangle(outerPen, 0, 0, width, height);

                // Draw an inset inner rectangle
                int inset = 20;
                Pen innerPen = new Pen(Color.Blue, 5);
                graphics.DrawRectangle(innerPen, inset, inset, width - 2 * inset, height - 2 * inset);

                // Save the image (output path is already bound via FileCreateSource)
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
 * 1. When a developer needs to programmatically generate a BMP placeholder image with a thick black border and a blue inner rectangle for UI mockups using C# and Aspose.Imaging.
 * 2. When an automated report generator must create simple diagrammatic graphics, such as a bordered thumbnail with a highlighted inner area, by drawing rectangles on a BMP file with Aspose.Imaging.
 * 3. When a game asset pipeline requires drawing a bold outer frame and an inset rectangle on a BMP sprite sheet to define collision zones or safe‑area guides via C# graphics operations.
 * 4. When a document processing system has to embed a BMP image that includes a visible border and a colored inner rectangle to indicate watermark or annotation zones using Aspose.Imaging's Graphics class.
 * 5. When a testing suite needs to produce a BMP test image with defined outer and inner rectangles to validate image rendering, file creation, and pen thickness handling in .NET.
 */