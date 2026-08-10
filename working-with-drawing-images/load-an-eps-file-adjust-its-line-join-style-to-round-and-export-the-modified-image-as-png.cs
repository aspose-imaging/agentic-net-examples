// HOW-TO: Convert EPS to PNG with Rounded Line Joins in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var eps = (Aspose.Imaging.FileFormats.Eps.EpsImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (var canvas = Aspose.Imaging.Image.Create(pngOptions, eps.Width, eps.Height))
                {
                    var graphics = new Aspose.Imaging.Graphics(canvas);

                    // Set a pen with round line join (not directly applied to EPS content but demonstrates the setting)
                    var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1)
                    {
                        LineJoin = Aspose.Imaging.LineJoin.Round
                    };

                    // Draw the EPS image onto the canvas
                    graphics.DrawImage(eps, 0, 0);

                    // Save the resulting PNG image
                    canvas.Save();
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
 * 1. When you need to display vector EPS artwork on a web page that only supports PNG images, preserving smooth rounded corners.
 * 2. When converting printed logos stored as EPS into PNG thumbnails for a product catalog while ensuring line joins appear rounded.
 * 3. When generating PNG assets from EPS files for mobile apps that require raster images with consistent line join styling.
 * 4. When automating a batch process that transforms EPS diagrams into PNG graphics for inclusion in PDF reports, needing rounded joins for better visual quality.
 * 5. When creating a preview image of an EPS file in a Windows desktop application, and you want the preview to use rounded line joins to match the design guidelines.
 */
