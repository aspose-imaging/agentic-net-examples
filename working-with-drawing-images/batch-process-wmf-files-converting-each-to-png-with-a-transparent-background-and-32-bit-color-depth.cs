using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.wmf");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.ColorType = PngColorType.TruecolorWithAlpha;
                        pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.Transparent,
                            PageSize = image.Size
                        };

                        image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a large collection of legacy WMF vector graphics into web‑ready PNG images with a transparent background and 32‑bit truecolor for use on a website.
 * 2. When an automation script must prepare printable assets by rasterizing WMF icons into high‑quality PNG files while preserving the alpha channel for overlay in a desktop application.
 * 3. When a migration tool has to replace old Windows Metafile assets in a document management system with PNG equivalents that support transparency and consistent color depth.
 * 4. When a CI/CD pipeline should validate that all WMF files in a repository are correctly rendered as PNGs with alpha transparency before publishing to a design library.
 * 5. When a batch image processing utility needs to read WMF files from an input folder, apply vector rasterization options, and save them as PNGs with truecolor‑with‑alpha to ensure compatibility with modern UI frameworks.
 */