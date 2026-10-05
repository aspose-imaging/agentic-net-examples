// HOW-TO: Create BMP Thumbnails with Black Border Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            Directory.CreateDirectory(outputDir);

            var files = Directory.GetFiles(inputDir, "*.bmp");
            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached)
                        image.CacheData();

                    int maxSize = 100;
                    int thumbWidth = image.Width;
                    int thumbHeight = image.Height;

                    if (thumbWidth > thumbHeight)
                    {
                        if (thumbWidth > maxSize)
                        {
                            thumbHeight = thumbHeight * maxSize / thumbWidth;
                            thumbWidth = maxSize;
                        }
                    }
                    else
                    {
                        if (thumbHeight > maxSize)
                        {
                            thumbWidth = thumbWidth * maxSize / thumbHeight;
                            thumbHeight = maxSize;
                        }
                    }

                    image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                    Graphics graphics = new Graphics(image);
                    Pen pen = new Pen(Color.Black, 2);
                    Rectangle borderRect = new Rectangle(0, 0, image.Width - 1, image.Height - 1);
                    graphics.DrawRectangle(pen, borderRect);

                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileName + "_thumb.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    BmpOptions options = new BmpOptions();
                    options.Source = new FileCreateSource(outputPath, false);
                    image.Save(outputPath, options);
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
 * 1. When you need to generate small preview images of BMP files for a web gallery and want each preview to have a consistent thin border.
 * 2. When an application must batch‑process a folder of BMP assets to create uniformly sized thumbnails for faster loading in a UI.
 * 3. When you want to add a visual frame around BMP images before exporting them to a PDF or report to improve readability.
 * 4. When a legacy system stores graphics as BMP and you need to create reduced‑size versions with a border for printing labels or receipts.
 * 5. When you are building a photo‑management tool that automatically resizes and decorates BMP pictures for display on mobile devices.
 */
