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
            // Define output path
            string outputPath = @"C:\temp\draw_perf.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a bound file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Measure drawing time
                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();

                // Drawing operations
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 10), new Point(490, 10));
                graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(50, 50, 400, 300));
                graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(100, 100, 200, 150));
                using (SolidBrush brush = new SolidBrush(Color.Green))
                {
                    graphics.DrawString("Performance Test", new Font("Arial", 24), brush, new PointF(150, 400));
                }

                stopwatch.Stop();
                Console.WriteLine($"Drawing time: {stopwatch.ElapsedMilliseconds} ms");

                // Save the image (already bound to outputPath)
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
 * 1. When a developer needs to benchmark how long drawing lines, rectangles, ellipses, and text takes on a 500×500 PNG image using Aspose.Imaging for .NET.
 * 2. When a performance test is required to compare the impact of different pen widths or brush colors on rendering speed in C# graphics code.
 * 3. When optimizing an image generation service that creates dynamic charts, the code can measure the draw time to ensure response times stay within SLA limits.
 * 4. When profiling the effect of file I/O versus in‑memory drawing by using a bound FileCreateSource and Stopwatch to isolate rendering overhead.
 * 5. When validating that a new version of Aspose.Imaging maintains or improves drawing performance for high‑resolution PNG exports in a Windows desktop application.
 */