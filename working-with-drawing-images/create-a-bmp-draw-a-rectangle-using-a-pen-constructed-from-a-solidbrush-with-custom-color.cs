using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image canvas
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Create a solid brush with a custom color
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    // Create a pen from the solid brush
                    Pen pen = new Pen(brush);

                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(image);

                    // Clear the canvas with white background
                    graphics.Clear(Color.White);

                    // Draw a rectangle using the pen
                    graphics.DrawRectangle(pen, new Rectangle(50, 50, 100, 100));

                    // Save the image
                    image.Save();
                }
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
 * 1. When a developer needs to generate a 24‑bit BMP thumbnail with a blue rectangular border for a product catalog in a C# ASP.NET application using Aspose.Imaging.
 * 2. When an automated reporting tool must create a BMP diagram that highlights a specific area by drawing a rectangle with a custom SolidBrush color on a white canvas.
 * 3. When a Windows desktop utility requires programmatically drawing a colored rectangle onto a BMP file to indicate selection zones in a screenshot editor built with C#.
 * 4. When a batch image processing script has to add a blue outline to BMP assets for branding purposes, using Aspose.Imaging’s Pen and SolidBrush classes.
 * 5. When a game development pipeline needs to generate placeholder BMP textures with simple geometric shapes, such as a rectangle drawn with a custom color, to test rendering pipelines in .NET.
 */