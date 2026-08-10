// HOW-TO: Create BMP Image and Draw Colored Rectangle with Pen in C# (Aspose.Imaging for .NET)
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
        // Hardcoded paths
        string outputPath = @"C:\Temp\output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP image options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };

            // Create a new BMP image (200x200 pixels)
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Create a SolidBrush with a custom color (e.g., semi‑transparent blue)
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 128, 255));

                // Construct a Pen from the SolidBrush's color
                Pen pen = new Pen(solidBrush.Color, 5); // 5‑pixel wide pen

                // Draw a rectangle using the pen
                graphics.DrawRectangle(pen, 20, 20, 160, 160);

                // Save the BMP image to the output path
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
 * 1. When you need to generate a 200×200 BMP thumbnail with a blue border for a reporting dashboard.
 * 2. When you want to programmatically add a colored rectangle overlay to an existing bitmap for watermarking purposes.
 * 3. When you are building a C# utility that creates simple diagram elements, such as boxes, directly in BMP files without using external editors.
 * 4. When you must produce a BMP file with a custom‑colored outline to highlight regions in image‑processing pipelines.
 * 5. When you are automating the creation of test images that contain precise geometric shapes for computer‑vision algorithm validation.
 */
