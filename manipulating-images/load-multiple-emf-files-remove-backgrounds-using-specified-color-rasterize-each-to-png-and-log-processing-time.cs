// HOW-TO: Batch Convert EMF to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputEmf";
            string outputDirectory = "OutputPng";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Stopwatch sw = Stopwatch.StartNew();

                using (Image image = Image.Load(inputPath))
                {
                    VectorImage vectorImage = image as VectorImage;
                    if (vectorImage != null)
                    {
                        vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.Transparent,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };

                    image.Save(outputPath, pngOptions);
                }

                sw.Stop();
                Console.WriteLine($"Processed {Path.GetFileName(inputPath)} in {sw.ElapsedMilliseconds} ms.");
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
 * 1. When you need to convert a folder of vector EMF drawings into PNG images with transparent backgrounds for web display.
 * 2. When you want to automatically remove any solid background from EMF files before rasterizing them for inclusion in a PDF report.
 * 3. When you have to process large numbers of EMF icons and generate PNG assets while measuring the time each conversion takes.
 * 4. When you need to integrate a C# routine that prepares EMF graphics for mobile apps by producing PNG files with alpha channels.
 * 5. When you are building a batch image pipeline that cleans up legacy EMF files and outputs high‑quality PNGs for a content management system.
 */
