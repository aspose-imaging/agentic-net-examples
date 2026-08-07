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
            // Output BMP file path (hardcoded)
            string outputPath = @"C:\temp\ellipse.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and bind to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with white background
                graphics.Clear(Color.White);

                // Draw an ellipse with a blue pen
                graphics.DrawEllipse(
                    new Pen(Color.Blue, 3),
                    new Rectangle(100, 100, 300, 200));

                // Reset any transformations applied to the graphics object
                graphics.ResetTransform();

                // Save the image (output is already bound to the file)
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
 * 1. When a developer needs to generate a 24‑bit BMP file in C# and draw a precise blue ellipse for a printable report or technical diagram, this code creates the image and saves it directly to disk.
 * 2. When an application must programmatically produce a simple placeholder image with an ellipse shape for UI testing or mock‑up generation, the example shows how to clear the canvas, draw the shape, and output a BMP file.
 * 3. When a developer wants to ensure that any subsequent drawing operations start from the default coordinate system after applying transformations, the use of Graphics.ResetTransform in the code resets the transform state.
 * 4. When a batch process has to create a series of BMP thumbnails that include an elliptical highlight around a region of interest, this snippet demonstrates the core steps of image creation, ellipse drawing, and saving.
 * 5. When integrating Aspose.Imaging into a .NET service that dynamically generates custom BMP assets for embedded devices, the example provides a straightforward way to draw vector graphics (ellipse) and finalize the image without additional file handling.
 */