using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Create graphics for drawing
                Graphics graphics = new Graphics(image);

                // Define a pen with sub-pixel width
                Pen pen = new Pen(Color.Red, 1.5f);

                // Draw a line using floating-point coordinates for sub-pixel accuracy
                graphics.DrawLine(pen, 10.3f, 20.7f, 200.8f, 150.2f);

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
 * 1. When a developer needs to add a precise red annotation line to an existing BMP file, such as marking a measurement on a scanned blueprint, and wants sub‑pixel accuracy using floating‑point coordinates.
 * 2. When a C# application must overlay a thin, anti‑aliased line on a bitmap image for a UI overlay or watermark without rasterizing to a higher resolution.
 * 3. When a software tool generates custom graphics on BMP screenshots, like drawing a guide line on a game capture, and requires the line to be positioned at non‑integer pixel locations for smoother appearance.
 * 4. When an image‑processing pipeline needs to programmatically modify legacy BMP assets by drawing diagnostic lines with a 1.5‑pixel wide pen to highlight defects.
 * 5. When a developer is building a reporting system that draws precise trend lines on BMP charts and must preserve the original BMP format while using Aspose.Imaging’s Graphics.DrawLine overload for sub‑pixel rendering.
 */