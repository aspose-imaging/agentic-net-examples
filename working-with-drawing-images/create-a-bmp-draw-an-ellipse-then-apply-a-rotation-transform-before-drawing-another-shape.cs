using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = "output/output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500×500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Draw an ellipse
                Pen ellipsePen = new Pen(Color.Blue, 3);
                graphics.DrawEllipse(ellipsePen, new Rectangle(100, 100, 300, 150));

                // Apply a 45‑degree rotation transform
                graphics.RotateTransform(45);

                // Draw a rectangle after rotation
                Pen rectPen = new Pen(Color.Red, 3);
                graphics.DrawRectangle(rectPen, new Rectangle(150, 150, 200, 100));

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a BMP file with custom vector graphics, such as an ellipse and a rotated rectangle, for use in legacy Windows applications or printing workflows.
 * 2. When creating a simple diagram or badge in C# where precise control over shape positioning and rotation is required, leveraging Aspose.Imaging’s Graphics API.
 * 3. When producing test images for automated UI testing that must include specific geometric shapes and transformations to validate rendering pipelines.
 * 4. When exporting design assets from a .NET service to a 24‑bit BMP format for compatibility with embedded systems that only support basic image formats.
 * 5. When building a server‑side image generation tool that programmatically draws shapes and applies rotation before saving the result as a BMP for downstream processing.
 */