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
            // Hardcoded output path
            string outputPath = @"C:\temp\yellow.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a FileStream for the output file
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set up BMP options with the stream as source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(stream);

                // Create a 400x400 BMP image bound to the stream
                using (Image image = Image.Create(bmpOptions, 400, 400))
                {
                    // Fill the entire image with yellow
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.Yellow);

                    // Save the bound image
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
 * 1. When a developer needs to programmatically generate a 400 × 400 BMP placeholder image filled with yellow for UI mock‑ups using Aspose.Imaging’s BmpOptions and a FileStream in C#.
 * 2. When an automated test suite must create a solid‑color BMP file on disk to verify that downstream image‑processing components correctly read and handle 24‑bit BMP streams.
 * 3. When an embedded‑device firmware build requires a yellow BMP bitmap of a specific size to be bundled as a resource, and the developer wants to generate it at build time with C# and Aspose.Imaging.
 * 4. When a reporting tool needs to embed a simple yellow color swatch BMP into PDF or Word documents, and the developer uses a FileStream‑based BmpOptions to create the image on the fly.
 * 5. When a batch conversion utility must produce a series of solid‑color BMP files for calibration of printers or displays, and the code uses Aspose.Imaging’s Graphics.Clear method to fill the image with yellow.
 */