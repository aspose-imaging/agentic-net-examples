using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output file paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Create a graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear the image to light gray
                graphics.Clear(Color.LightGray);

                // Set up grid parameters
                int spacing = 50; // distance between lines
                Pen redPen = new Pen(Color.Red, 1);
                int width = image.Width;
                int height = image.Height;

                // Draw vertical grid lines
                for (int x = 0; x <= width; x += spacing)
                {
                    graphics.DrawLine(redPen, new Point(x, 0), new Point(x, height));
                }

                // Draw horizontal grid lines
                for (int y = 0; y <= height; y += spacing)
                {
                    graphics.DrawLine(redPen, new Point(0, y), new Point(width, y));
                }

                // Save the modified image to the output path
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
 * 1. When a developer needs to generate a light‑gray BMP canvas and overlay a red grid for a printable engineering diagram, this code provides a quick solution.
 * 2. When creating test images for computer‑vision models that require a uniform background with known grid patterns, the snippet clears a BMP to light gray and draws precise red lines.
 * 3. When preparing printable graph paper or worksheet templates in BMP format, a developer can use this example to set the page color and add evenly spaced red grid lines.
 * 4. When building a UI component that visualizes coordinate systems by rendering a BMP with a light‑gray fill and a red grid, the code demonstrates how to use Aspose.Imaging’s Graphics, Pen, and drawing methods in C#.
 * 5. When automating the creation of template images for game level design where a light‑gray background and a red grid help designers align assets, this example shows how to clear and draw on a BMP file programmatically.
 */