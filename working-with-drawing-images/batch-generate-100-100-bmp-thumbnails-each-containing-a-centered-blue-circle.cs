// HOW-TO: Create 100x100 BMP Thumbnails with Blue Circle in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] files = Directory.GetFiles(inputDir);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + "_thumb.bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };
                using (BmpImage canvas = (BmpImage)Image.Create(options, 100, 100))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);
                    SolidBrush brush = new SolidBrush(Color.Blue);
                    Rectangle circleRect = new Rectangle(10, 10, 80, 80);
                    graphics.FillEllipse(brush, circleRect);
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
 * 1. When you need to generate small BMP preview images for a collection of files to display in a Windows desktop application.
 * 2. When you want to automatically create 100 × 100 icons with a blue circular logo for a product catalog stored as BMP files.
 * 3. When a batch process must add a consistent visual marker (blue circle) to each image before uploading to a legacy system that only accepts BMP format.
 * 4. When you are building a game asset pipeline that requires uniform 100 px BMP sprites with a centered circle for collision testing.
 * 5. When you need to convert a folder of source images into BMP thumbnails for printing proofs while preserving a simple vector‑style graphic.
 */
