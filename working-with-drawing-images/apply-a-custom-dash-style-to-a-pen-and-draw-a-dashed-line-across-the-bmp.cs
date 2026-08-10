// HOW-TO: Draw Custom Dashed Line on BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
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

            // Load the existing BMP image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Create a Graphics object for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Create a Pen with custom dash style
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5f);
                pen.DashStyle = Aspose.Imaging.DashStyle.Custom;
                pen.DashPattern = new float[] { 10f, 5f }; // dash length 10, space length 5

                // Draw a diagonal dashed line across the image
                graphics.DrawLine(
                    pen,
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(image.Width - 1, image.Height - 1));

                // Save the modified image as BMP
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;
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
 * 1. When you need to add a stylized diagonal guide or annotation to an existing BMP file, such as marking a region of interest in a technical diagram.
 * 2. When generating printable engineering drawings that require a custom dash pattern to differentiate measurement lines from other graphics.
 * 3. When creating a watermark or branding element that appears as a dashed line across a bitmap image without altering its original resolution.
 * 4. When programmatically preparing BMP assets for a game or UI where a dashed separator line must be drawn at runtime.
 * 5. When automating batch processing of BMP files to overlay custom dashed lines for quality‑control markings or visual cues.
 */
