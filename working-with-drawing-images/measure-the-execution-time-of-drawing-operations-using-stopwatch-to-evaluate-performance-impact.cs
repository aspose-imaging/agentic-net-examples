using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.bmp";
            string outputPath = @"c:\temp\output.png";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the input image as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Create Graphics instance for drawing
                Graphics graphics = new Graphics(raster);

                // Measure drawing time
                var stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();

                // Drawing operations
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawLine(new Pen(Aspose.Imaging.Color.Black, 2), new Point(50, 50), new Point(200, 200));
                graphics.DrawRectangle(new Pen(Aspose.Imaging.Color.Blue, 3), new Rectangle(100, 100, 150, 100));
                graphics.DrawEllipse(new Pen(Aspose.Imaging.Color.Green, 2), new Rectangle(120, 120, 80, 80));

                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillRectangle(brush, new Rectangle(260, 150, 120, 60));
                }

                using (SolidBrush textBrush = new SolidBrush(Aspose.Imaging.Color.Purple))
                {
                    graphics.DrawString("Performance Test", new Font("Arial", 24), textBrush, new PointF(50, 250));
                }

                stopwatch.Stop();
                Console.WriteLine($"Drawing time: {stopwatch.Elapsed}");

                // Save the modified image to output path as PNG
                using (FileStream outStream = new FileStream(outputPath, FileMode.Create))
                {
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.Source = new StreamSource(outStream);
                    raster.Save(outputPath, pngOptions);
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
 * 1. When generating thumbnails or watermarked PNG images from BMP sources in a batch processing service, a developer can use Stopwatch to benchmark how long the drawing (lines, rectangles, text) takes and optimize the pipeline.
 * 2. When building a real‑time charting component that draws shapes on raster images, measuring the drawing time helps ensure the rendering stays within UI frame‑rate limits.
 * 3. When converting legacy BMP files to modern PNG format with added annotations, developers can log Stopwatch results to compare performance across different pen widths or brush types.
 * 4. When implementing a server‑side image‑generation API that must meet SLA response times, the Stopwatch can verify that the combined Clear, DrawLine, DrawRectangle, DrawEllipse, and FillRectangle operations complete within the required threshold.
 * 5. When profiling the impact of different font sizes or graphics objects on C# image processing tasks, Stopwatch provides quantitative data to decide whether to cache graphics resources or adjust drawing complexity.
 */