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
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a new image with the specified dimensions
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Initialize Graphics from the created image
                    Graphics graphics = new Graphics(image);

                    // Set smoothing mode to AntiAlias for smoother edges
                    graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                    // Clear the background
                    graphics.Clear(Aspose.Imaging.Color.Wheat);

                    // Draw a sample rectangle
                    graphics.DrawRectangle(new Pen(Aspose.Imaging.Color.Black, 2), new Rectangle(50, 50, 400, 400));

                    // Save the image
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
 * 1. When generating a PNG thumbnail with smooth borders for a web gallery, a developer can use this code to draw shapes with anti‑aliased edges.
 * 2. When creating a printable PDF cover page that requires a crisp rectangular frame, the code initializes Graphics from an image and sets SmoothingMode to AntiAlias.
 * 3. When building a custom charting component that outputs PNG charts, the developer uses this pattern to ensure lines and rectangles are rendered without jagged edges.
 * 4. When automating the production of UI mock‑ups where background colors and precise rectangle outlines are needed, the code demonstrates how to clear the canvas and draw a smooth rectangle.
 * 5. When developing a batch image processing tool that writes PNG files to a specific folder, this snippet shows how to create the image via a FileStream, apply anti‑aliasing, and save the result.
 */