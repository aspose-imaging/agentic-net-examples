using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new PNG image (300 × 200 pixels)
            PngOptions pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, 300, 200))
            {
                // Obtain a Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Rectangle parameters
                int x = 50;
                int y = 30;
                int width = 200;
                int height = 120;

                // Fill the rectangle with solid blue
                SolidBrush blueBrush = new SolidBrush(Color.Blue);
                graphics.FillRectangle(blueBrush, x, y, width, height);

                // Outline the rectangle with a thick black pen (5 px)
                Pen blackPen = new Pen(Color.Black, 5);
                graphics.DrawRectangle(blackPen, x, y, width, height);

                // Save the resulting image
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
 * 1. When a developer needs to generate a PNG placeholder image with a colored region highlighted by a thick border for UI mock‑ups, they can use Aspose.Imaging to fill a blue rectangle with SolidBrush and outline it with a 5 px black Pen.
 * 2. When creating printable reports that require a colored banner rendered as an image, the code can produce a 300 × 200 PNG with a solid blue rectangle and a bold black outline using C# Graphics.
 * 3. When building a web service that returns dynamically generated thumbnails with a highlighted selection area, the developer can employ Aspose.Imaging to draw a filled blue rectangle and frame it with a thick black pen.
 * 4. When implementing a simple image‑based watermark that emphasizes a region of interest, the code demonstrates how to overlay a solid blue rectangle and a black border onto a PNG using Aspose.Imaging’s FillRectangle and DrawRectangle methods.
 * 5. When developing a diagnostic tool that visualizes bounding boxes around detected objects in an image, the snippet shows how to render each box as a blue‑filled rectangle with a thick black outline in a PNG file.
 */