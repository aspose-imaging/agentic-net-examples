using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"c:\temp\output.png";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var pngOptions = new PngOptions();
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                var graphics = new Aspose.Imaging.Graphics(image);

                var stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();

                graphics.Clear(Aspose.Imaging.Color.Wheat);
                graphics.DrawLine(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Point(450, 450));
                graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3), new Aspose.Imaging.Rectangle(100, 100, 300, 200));
                graphics.DrawEllipse(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2), new Aspose.Imaging.Rectangle(150, 150, 200, 200));

                using (var brush = new SolidBrush(Aspose.Imaging.Color.Green))
                {
                    graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(200, 200, 100, 100));
                }

                using (var textBrush = new SolidBrush(Aspose.Imaging.Color.Black))
                {
                    graphics.DrawString("Performance Test", new Aspose.Imaging.Font("Arial", 24), textBrush, new Aspose.Imaging.PointF(150, 30));
                }

                stopwatch.Stop();
                Console.WriteLine($"Drawing time: {stopwatch.ElapsedMilliseconds} ms");

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
 * 1. When generating high‑resolution PNG reports with multiple shapes and text, a developer can use this code to benchmark how long the drawing operations take and ensure the rendering stays within acceptable performance limits.
 * 2. When building a server‑side image thumbnail service that clears the canvas, draws lines, rectangles, ellipses and fills areas, measuring the elapsed milliseconds helps decide whether the service can handle the expected request volume.
 * 3. When optimizing a C# application that creates custom charts using Aspose.Imaging.Graphics, the Stopwatch timing lets the developer compare different pen widths, brush types, or font settings to find the fastest rendering configuration.
 * 4. When integrating dynamic watermarking into PDF‑to‑image conversion pipelines, the code can be used to profile the time spent drawing the watermark text and shapes on a PNG before saving the final file.
 * 5. When testing the impact of new hardware or .NET runtime updates on image processing speed, the developer can run this drawing routine and record the Stopwatch result to verify performance improvements across PNG output.
 */