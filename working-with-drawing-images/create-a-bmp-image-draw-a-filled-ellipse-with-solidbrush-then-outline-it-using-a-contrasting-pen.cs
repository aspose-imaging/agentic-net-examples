// HOW-TO: Create BMP Image With Filled And Outlined Ellipse In C# (Aspose.Imaging for .NET)
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
        // Hardcoded output path
        string outputPath = @"C:\temp\ellipse_output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;

            // Create a new BMP image (400x400)
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define the bounding rectangle for the ellipse
                Rectangle ellipseRect = new Rectangle(50, 50, 300, 200);

                // Fill the ellipse with a solid brush (light blue)
                SolidBrush fillBrush = new SolidBrush(Color.LightBlue);
                graphics.FillEllipse(fillBrush, ellipseRect);

                // Outline the ellipse with a contrasting pen (dark blue, width 3)
                Pen outlinePen = new Pen(Color.DarkBlue, 3);
                graphics.DrawEllipse(outlinePen, ellipseRect);

                // Save the image to the specified path
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
 * 1. When you need to generate a BMP file that contains a colored ellipse for a report or thumbnail in a C# desktop application.
 * 2. When you want to programmatically create a simple diagram, such as a highlighted area or button background, using Aspose.Imaging’s drawing API.
 * 3. When an automated process must produce a 24‑bit bitmap with a solid‑filled shape and a contrasting border for printing or legacy system compatibility.
 * 4. When you are building a game or UI prototype that requires dynamic creation of ellipse graphics without relying on external image assets.
 * 5. When you need to batch‑create placeholder images with consistent dimensions and styling (filled ellipse with outline) for testing image‑processing pipelines.
 */
