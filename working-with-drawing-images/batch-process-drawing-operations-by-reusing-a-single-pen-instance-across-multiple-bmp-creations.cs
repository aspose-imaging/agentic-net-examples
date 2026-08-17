// HOW-TO: Create Multiple BMP Images with Shared Pen in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Define output file paths (hard‑coded literals as required)
            string[] outputPaths = {
                @"C:\temp\output1.bmp",
                @"C:\temp\output2.bmp",
                @"C:\temp\output3.bmp"
            };

            // Reuse a single Pen instance for all drawing operations
            var sharedPen = new Pen(Color.Blue, 3f);

            foreach (string outputPath in outputPaths)
            {
                // Ensure the output directory exists (unconditional call)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set BMP creation options
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24
                };

                // Create a new BMP image (500x500 pixels)
                using (Image image = Image.Create(bmpOptions, 500, 500))
                {
                    // Initialize graphics object for drawing
                    var graphics = new Graphics(image);

                    // Clear background to white
                    graphics.Clear(Color.White);

                    // Draw a rectangle using the shared Pen
                    graphics.DrawRectangle(sharedPen, 50, 50, 400, 400);

                    // Draw an ellipse using the same Pen
                    graphics.DrawEllipse(sharedPen, new Rectangle(100, 100, 300, 200));

                    // Save the image to the specified output path
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a series of BMP files that contain the same styled shapes, such as rectangles and ellipses, without recreating the Pen for each image.
 * 2. When automating the production of placeholder graphics for UI mockups, reusing a single Pen improves performance while drawing consistent outlines across multiple images.
 * 3. When building a batch job that creates printable BMP assets for a catalog, sharing the Pen instance reduces memory overhead during the loop.
 * 4. When generating test images for computer‑vision algorithms, you can quickly produce several BMP samples with identical drawing parameters using Aspose.Imaging.
 * 5. When exporting diagram elements to BMP format in a server‑side C# service, reusing the Pen ensures consistent line thickness and color across all exported files.
 */
