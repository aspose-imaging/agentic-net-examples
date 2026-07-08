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
            // Output file path (hardcoded)
            string outputPath = @"C:\temp\output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set up PNG options with the stream as the source
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a new image with the specified dimensions
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Initialize graphics for the image
                    Graphics graphics = new Graphics(image);

                    // Clear the graphics surface with a light gray background
                    graphics.Clear(Color.LightGray);

                    // Save the image (stream is already bound)
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
 * 1. When generating a placeholder PNG thumbnail for a web gallery and you need a uniform light‑gray background before adding overlay text.
 * 2. When creating a printable report page as an image where the canvas must be cleared to a neutral light gray to ensure consistent background across different PDF conversions.
 * 3. When initializing a blank canvas for a dynamic chart in a Windows service, using Aspose.Imaging to clear the surface to light gray before drawing data series.
 * 4. When building an automated email system that attaches a PNG badge, you clear the graphics surface to light gray to guarantee a clean background regardless of the recipient’s email client.
 * 5. When developing a batch image processing tool that generates 500×500 PNG icons, you use Graphics.Clear with Color.LightGray to reset each new image before applying icon graphics.
 */