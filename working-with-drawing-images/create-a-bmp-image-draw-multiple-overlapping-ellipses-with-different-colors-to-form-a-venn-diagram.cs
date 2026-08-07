using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\venn.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Define bounding rectangles for three overlapping ellipses
                RectangleF rect1 = new RectangleF(100, 100, 250, 250);
                RectangleF rect2 = new RectangleF(150, 100, 250, 250);
                RectangleF rect3 = new RectangleF(125, 150, 250, 250);

                // Draw ellipses with semi‑transparent colors to form a Venn diagram
                graphics.DrawEllipse(new Pen(Color.FromArgb(128, 255, 0, 0), 2), rect1); // Red
                graphics.DrawEllipse(new Pen(Color.FromArgb(128, 0, 255, 0), 2), rect2); // Green
                graphics.DrawEllipse(new Pen(Color.FromArgb(128, 0, 0, 255), 2), rect3); // Blue

                // Save the image
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
 * 1. When a developer needs to generate a BMP file that visualizes set relationships as a Venn diagram for a Windows desktop reporting tool.
 * 2. When an application must programmatically create overlapping colored ellipses in a 500x500 bitmap to illustrate data intersections in a scientific presentation.
 * 3. When an automated batch process has to produce high‑resolution BMP images with semi‑transparent red, green, and blue circles for printing marketing materials.
 * 4. When a C# service uses Aspose.Imaging to render a Venn diagram on the fly and save it to a file system for later retrieval by a web API.
 * 5. When a developer wants to demonstrate basic image processing operations—such as creating a bitmap, clearing the background, and drawing ellipses with pens—in a tutorial or code sample.
 */