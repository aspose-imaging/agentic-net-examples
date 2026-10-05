// HOW-TO: Batch Convert CDR Files to 800x600 PNG Images in C# (Aspose.Imaging for .NET)
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
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new CdrRasterizationOptions
                            {
                                PageWidth = 800,
                                PageHeight = 600
                            }
                        };

                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            raster.Save(outputPath, new PngOptions());
                        }
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
 * 1. When a design studio needs to generate web‑ready thumbnails from a folder of CorelDRAW (.cdr) artwork automatically.
 * 2. When an e‑commerce platform must convert product illustrations stored as CDR files into 800×600 PNGs for display on product pages.
 * 3. When a migration script has to batch‑process legacy CDR assets into PNG format with a fixed size for a mobile app’s image cache.
 * 4. When a reporting tool requires rasterizing multiple vector CDR diagrams into PNG charts that fit a predefined layout.
 * 5. When an automated build pipeline must ensure all CDR source files are resized and saved as PNGs for cross‑platform compatibility.
 */
