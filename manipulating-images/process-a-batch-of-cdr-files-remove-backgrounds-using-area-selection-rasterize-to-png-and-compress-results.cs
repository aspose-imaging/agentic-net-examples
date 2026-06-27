using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    cdr.RemoveBackground(new RemoveBackgroundSettings());

                    PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageSize = cdr.Size,
                            BackgroundColor = Aspose.Imaging.Color.Transparent
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
 * 1. When a graphic design studio needs to convert a large collection of CorelDRAW (.cdr) illustrations into web‑ready PNGs with transparent backgrounds and maximum zip compression, they can use this C# batch‑processing code.
 * 2. When an e‑commerce platform wants to automatically strip the background from vendor‑supplied CDR product mockups and generate lightweight PNG thumbnails for catalog pages, this script provides the needed image‑processing pipeline.
 * 3. When a document management system must archive legacy CDR files as lossless PNG assets while preserving vector quality through rasterization and removing unwanted backgrounds, developers can employ this code.
 * 4. When a marketing automation tool has to prepare a series of promotional graphics by converting CDR source files to PNG with transparent backgrounds and high compression before emailing them, the example offers a ready‑to‑use solution.
 * 5. When a cloud‑based image‑conversion service needs to process multiple CDR files in one run, apply background removal, rasterize each page to the original size, and output compressed PNGs for downstream analytics, this C# implementation fulfills the requirement.
 */