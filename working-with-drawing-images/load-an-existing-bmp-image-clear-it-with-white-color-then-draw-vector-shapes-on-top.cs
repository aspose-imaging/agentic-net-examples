using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a Graphics instance for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with white color
                graphics.Clear(Color.White);

                // Draw a red rectangle
                Pen redPen = new Pen(Color.Red, 3);
                graphics.DrawRectangle(redPen, new Rectangle(50, 50, 200, 150));

                // Draw a blue ellipse
                Pen bluePen = new Pen(Color.Blue, 2);
                graphics.DrawEllipse(bluePen, new Rectangle(300, 100, 150, 100));

                // Draw a green line
                Pen greenPen = new Pen(Color.Green, 4);
                graphics.DrawLine(greenPen, new Point(100, 300), new Point(400, 350));

                // Fill a yellow circle using a SolidBrush
                using (SolidBrush yellowBrush = new SolidBrush())
                {
                    yellowBrush.Color = Color.Yellow;
                    graphics.FillEllipse(yellowBrush, new Rectangle(200, 250, 80, 80));
                }

                // Save the modified image as BMP
                BmpOptions bmpOptions = new BmpOptions();
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
 * 1. When a developer needs to generate a clean white BMP canvas and overlay vector graphics such as rectangles, ellipses, and lines for a printable report or diagram.
 * 2. When an application must programmatically add branding elements like colored shapes to an existing BMP image before saving it for use in a Windows desktop UI.
 * 3. When a batch image processing tool has to clear old pixel data and redraw geometric annotations on BMP files for GIS or CAD workflows.
 * 4. When a developer wants to create a simple thumbnail preview by loading a BMP, clearing it, and drawing custom shapes to illustrate layout placeholders in a WPF application.
 * 5. When an automated testing framework needs to generate BMP screenshots with overlaid shapes to verify rendering accuracy of graphics components.
 */