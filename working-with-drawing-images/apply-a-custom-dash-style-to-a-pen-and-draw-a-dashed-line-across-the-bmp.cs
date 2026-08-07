using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";   // not used but kept for rule compliance
        string outputPath = "output.bmp";

        try
        {
            // Verify input file existence (rule 2)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (rule 3)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a new BMP image (200x100 pixels)
            using (Image image = Image.Create(new BmpOptions(), 200, 100))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Create a pen with black color, width 2
                Pen pen = new Pen(Color.Black, 2);

                // Apply a dashed style to the pen
                pen.DashStyle = DashStyle.Dash; // could also use DashStyle.Dot, etc.

                // Draw a dashed line across the image
                graphics.DrawLine(pen, 0, 0, 199, 99);

                // Save the resulting image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Unified error handling (rule 4)
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a BMP diagram with a dashed separator line for a printed report or PDF overlay.
 * 2. When creating a placeholder image that shows a dashed guideline for UI mockups in a Windows Forms application.
 * 3. When producing a test pattern BMP file that includes a dashed line to verify that custom dash styles are rendered correctly on different devices.
 * 4. When automating the creation of a BMP watermark that consists of a dashed line across the image to indicate a draft status.
 * 5. When building a batch process that adds a dashed border line to existing BMP assets for visual inspection in a quality‑control workflow.
 */