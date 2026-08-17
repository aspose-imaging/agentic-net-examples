// HOW-TO: Handle Unsupported Image Formats When Creating Graphics In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = null;
                try
                {
                    graphics = new Graphics(image);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Failed to create Graphics: {ex.Message}");
                    // Save the original image without drawing
                    image.Save(outputPath, new PngOptions());
                    return;
                }

                // Perform simple drawing operations
                graphics.Clear(Color.Wheat);
                graphics.DrawRectangle(new Pen(Color.Blue, 3), new Rectangle(10, 10, image.Width - 20, image.Height - 20));

                // Save the modified image
                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to load a JPEG, draw shapes, and safely fallback if the format cannot be used with Aspose.Imaging Graphics.
 * 2. When converting images to PNG while ensuring the application does not crash on unsupported source formats.
 * 3. When processing user‑uploaded photos and must validate that Graphics can be created before applying annotations.
 * 4. When automating batch image manipulation and want to log errors for files that Aspose.Imaging cannot render.
 * 5. When building a C# service that draws borders around images and must gracefully handle formats that do not support drawing operations.
 */
