using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int fileCount = 5;
            int width = 200;
            int height = 200;
            string outputDir = "Output";

            Directory.CreateDirectory(outputDir);

            Random rnd = new Random();

            for (int i = 0; i < fileCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"pattern_{i}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source fileSource = new FileCreateSource(outputPath, false);

                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    bmpOptions.Source = fileSource;

                    using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
                    {
                        Graphics graphics = new Graphics(canvas);

                        int lineCount = 10;
                        for (int j = 0; j < lineCount; j++)
                        {
                            int x1 = rnd.Next(width);
                            int y1 = rnd.Next(height);
                            int x2 = rnd.Next(width);
                            int y2 = rnd.Next(height);

                            Color lineColor = Color.FromArgb(
                                255,
                                (byte)rnd.Next(256),
                                (byte)rnd.Next(256),
                                (byte)rnd.Next(256));

                            Pen pen = new Pen(lineColor, 1);
                            graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                        }

                        canvas.Save();
                    }
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
 * 1. When a developer needs to batch generate BMP files with random line patterns for stress‑testing Aspose.Imaging image‑processing pipelines, this C# code provides a quick solution.
 * 2. When creating sample data sets for computer‑vision algorithms that require diverse line‑based textures in BMP format, the code can automatically produce the required images.
 * 3. When validating the performance of file‑IO operations and graphics rendering in a .NET application, developers can use this script to generate multiple random‑line BMP images on the fly.
 * 4. When preparing visual assets for UI testing where each BMP must contain unique random lines to simulate user‑drawn sketches, the code creates the necessary files in a single loop.
 * 5. When demonstrating Aspose.Imaging’s BmpOptions, Graphics, and Pen classes in tutorials or documentation, this example efficiently produces a set of distinct BMP images for illustration.
 */