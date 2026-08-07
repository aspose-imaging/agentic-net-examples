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
            string outputPath = @"C:\temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a PNG image using a stream source
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                PngOptions pngOptions = new PngOptions
                {
                    Source = new StreamSource(stream)
                };

                // Create a new image of size 400x300
                using (Image image = Image.Create(pngOptions, 400, 300))
                {
                    // Initialize graphics for the image
                    Graphics graphics = new Graphics(image);

                    // Clear the background with a wheat color
                    graphics.Clear(Color.Wheat);

                    // Define a floating‑point rectangle
                    RectangleF rect = new RectangleF(50.5f, 60.5f, 200.75f, 150.25f);

                    // Draw the rectangle using an orange pen of width 3
                    Pen pen = new Pen(Color.Orange, 3);
                    graphics.DrawRectangle(pen, rect);

                    // Save the image (the stream is already linked)
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
 * 1. When a developer needs to generate a PNG report image with precise sub‑pixel positioning of UI elements, they can use Aspose.Imaging Graphics.DrawRectangle overload with a RectangleF to draw a floating‑point rectangle.
 * 2. When creating custom thumbnails that require anti‑aliased borders, the code shows how to draw an orange‑colored rectangle with fractional coordinates on a 400×300 image.
 * 3. When building a CAD‑style overlay on top of a scanned document, the floating‑point rectangle lets you align measurement boxes accurately using C# and Aspose.Imaging.
 * 4. When automating the production of marketing banners where the rectangle dimensions must be calculated dynamically (e.g., based on user input), the RectangleF overload provides the needed precision.
 * 5. When developing a diagnostic tool that highlights regions of interest in medical PNG images, the code demonstrates how to draw a high‑resolution rectangle with a specific pen width and color using Aspose.Imaging.
 */