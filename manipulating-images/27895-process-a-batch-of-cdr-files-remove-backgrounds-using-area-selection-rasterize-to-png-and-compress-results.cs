using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputCdr";
            string outputDirectory = "OutputPng";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height,
                            BackgroundColor = Color.Transparent
                        }
                    };

                    cdr.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a large collection of CorelDRAW (.cdr) illustrations into web‑ready PNG images with transparent backgrounds for faster page loads, this C# batch‑processing code using Aspose.Imaging provides an automated solution.
 * 2. When a design team wants to archive their legacy CDR assets as lossless PNG files while preserving alpha channels for future reuse, the script rasterizes each page and saves it with compression.
 * 3. When an e‑commerce platform must generate product‑detail images from vendor‑supplied CDR files without background artifacts, the code batch‑processes the files and outputs PNGs ready for storefront integration.
 * 4. When a CI/CD pipeline requires automatic conversion of newly added CDR graphics into PNG thumbnails for documentation or preview panels, this Aspose.Imaging routine can be scheduled to run on each build.
 * 5. When a marketing department needs to mass‑export brand assets from CorelDRAW to PNG format while ensuring the background is removed for overlay on promotional materials, the program streamlines the task with a single C# loop.
 */