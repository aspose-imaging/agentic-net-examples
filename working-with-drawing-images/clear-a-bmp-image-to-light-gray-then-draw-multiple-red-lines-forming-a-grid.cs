// HOW-TO: Create Light Gray BMP with Red Grid Overlay in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Create graphics object for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear the canvas to light gray
                graphics.Clear(Aspose.Imaging.Color.LightGray);

                int width = image.Width;
                int height = image.Height;
                int cellSize = 50; // spacing between grid lines

                // Pen for grid lines (red, 1 pixel width)
                Aspose.Imaging.Pen redPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 1);

                // Draw vertical grid lines
                for (int x = 0; x <= width; x += cellSize)
                {
                    graphics.DrawLine(redPen,
                        new Aspose.Imaging.Point(x, 0),
                        new Aspose.Imaging.Point(x, height));
                }

                // Draw horizontal grid lines
                for (int y = 0; y <= height; y += cellSize)
                {
                    graphics.DrawLine(redPen,
                        new Aspose.Imaging.Point(0, y),
                        new Aspose.Imaging.Point(width, y));
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified image as BMP
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate a printable BMP template with a light‑gray background and a red grid to help users align content in a desktop application.
 * 2. When you want to programmatically add a visual guide to an existing bitmap for a game level editor that requires evenly spaced red lines.
 * 3. When you must create a diagnostic image that highlights coordinate divisions on a BMP for testing image‑processing algorithms in C#.
 * 4. When you are building a reporting tool that overlays a red grid on scanned BMP documents to assist manual measurement or annotation.
 * 5. When you need to prepare a BMP placeholder with a light gray canvas and a red grid for UI mockups or wireframes in a .NET project.
 */
