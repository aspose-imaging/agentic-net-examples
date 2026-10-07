// HOW-TO: Measure Drawing Performance With Stopwatch In Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);
                graphics.DrawRectangle(pen, 50, 50, 200, 150);

                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillRectangle(brush, 300, 100, 150, 100);
                }

                var stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < 100; i++)
                {
                    Aspose.Imaging.Pen p = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 1);
                    graphics.DrawLine(p, 0, i, image.Width, i);
                }

                stopwatch.Stop();
                Console.WriteLine($"Drawing time: {stopwatch.ElapsedMilliseconds} ms");

                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to benchmark how long bulk line‑drawing operations take on a PNG image using Aspose.Imaging in C#.
 * 2. When you want to compare the performance impact of different pen colors or thicknesses before finalizing a graphics‑heavy report generation.
 * 3. When you are optimizing a server‑side image‑processing service and need precise timing for each drawing loop to meet SLA requirements.
 * 4. When you are profiling custom annotation tools that draw shapes on user‑uploaded images to ensure they remain responsive.
 * 5. When you need to log execution time of drawing commands to decide whether to switch to a faster rendering technique or library.
 */
