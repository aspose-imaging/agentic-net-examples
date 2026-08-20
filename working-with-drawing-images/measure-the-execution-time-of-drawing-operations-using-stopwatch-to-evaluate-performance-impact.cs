// HOW-TO: Measure Performance of Drawing Shapes with Stopwatch in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.Wheat);

                    var stopwatch = new System.Diagnostics.Stopwatch();
                    stopwatch.Start();

                    graphics.DrawLine(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Point(450, 50));
                    graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3), new Aspose.Imaging.Rectangle(100, 100, 300, 200));
                    graphics.DrawEllipse(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2), new Aspose.Imaging.Rectangle(150, 150, 200, 100));

                    using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Green))
                    {
                        graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(200, 300, 100, 50));
                    }

                    using (SolidBrush textBrush = new SolidBrush(Aspose.Imaging.Color.Purple))
                    {
                        graphics.DrawString(
                            "Performance Test",
                            new Aspose.Imaging.Font("Arial", 24),
                            textBrush,
                            new Aspose.Imaging.PointF(150, 400));
                    }

                    stopwatch.Stop();
                    Console.WriteLine($"Drawing operations took {stopwatch.ElapsedMilliseconds} ms");

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
 * 1. When you need to benchmark how long basic drawing commands (lines, rectangles, ellipses) take in a PNG image generated with Aspose.Imaging for .NET.
 * 2. When you want to compare the performance impact of different pen widths or brush fills while creating graphics for reports or UI assets.
 * 3. When you are optimizing a server‑side image generation service and need precise timing data to meet latency requirements.
 * 4. When you are profiling the rendering speed of text and shapes before scaling the image size for high‑resolution printing.
 * 5. When you need to log execution time of drawing operations to decide whether to cache pre‑rendered graphics in a web application.
 */
