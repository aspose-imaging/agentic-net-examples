// HOW-TO: Create BMP With Rectangle And Translated Ellipse Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a BMP image
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Draw a blue rectangle
                graphics.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(50, 50, 200, 100));

                // Translate the origin
                graphics.TranslateTransform(100, 50);

                // Draw a red ellipse after translation
                graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(0, 0, 100, 100));

                // Save the image (output path is already bound)
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
 * 1. When you need to generate a BMP image that contains a highlighted rectangle and a second shape drawn after shifting the coordinate origin.
 * 2. When you want to programmatically add a rectangle and an offset ellipse to a bitmap for a custom UI thumbnail.
 * 3. When you need to create a simple diagram where the second shape is positioned relative to a moved origin, such as an offset map marker.
 * 4. When you are building a batch process that adds annotations or watermarks to BMP files by translating drawing coordinates.
 * 5. When you require a quick way to produce test images with multiple shapes for automated visual testing of graphics pipelines.
 */
