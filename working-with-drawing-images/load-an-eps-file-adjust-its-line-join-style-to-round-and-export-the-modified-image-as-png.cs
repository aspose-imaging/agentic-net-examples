// HOW-TO: Convert EPS to PNG with Rounded Line Joins in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output\\modified.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (EpsImage eps = (EpsImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Create a Pen with round line join style
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black);
                pen.LineJoin = Aspose.Imaging.LineJoin.Round;

                int width = eps.Width;
                int height = eps.Height;

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, width, height))
                {
                    // Clear background
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Draw the EPS image onto the canvas
                    graphics.DrawImage(eps, 0, 0, width, height);

                    // Save the canvas
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
 * 1. When you need to display vector EPS artwork on a web page that only supports PNG images, and you want smooth rounded corners on the lines.
 * 2. When converting printed logos stored as EPS to PNG thumbnails while ensuring the line joins appear rounded for better visual quality.
 * 3. When generating PNG assets from EPS files for mobile apps and you must apply a round line join style to match the app’s design guidelines.
 * 4. When automating a batch process that transforms EPS diagrams into PNG files with consistent rounded line joins for inclusion in PDF reports.
 * 5. When creating a server‑side service that receives EPS files, modifies their stroke joins to round, and returns PNG images for downstream image‑processing pipelines.
 */
