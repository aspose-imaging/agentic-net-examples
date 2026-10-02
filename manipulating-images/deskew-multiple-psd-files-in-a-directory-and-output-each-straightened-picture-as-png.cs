// HOW-TO: Batch Deskew PSD Files and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string file in files)
            {
                if (!Path.GetExtension(file).Equals(".psd", StringComparison.OrdinalIgnoreCase))
                    continue;

                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (RasterImage raster = (RasterImage)image)
                    {
                        if (!raster.IsCached)
                        {
                            raster.CacheData();
                        }

                        raster.NormalizeAngle(false, Color.LightGray);

                        using (PngOptions pngOptions = new PngOptions())
                        {
                            raster.Save(outputPath, pngOptions);
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
 * 1. When you need to automatically straighten scanned Photoshop documents before publishing them as web‑ready PNGs.
 * 2. When a workflow must process dozens of PSD layers from a photography studio and output corrected PNG previews.
 * 3. When an e‑commerce platform requires batch correction of product mockups saved as PSDs to ensure they display upright on the site.
 * 4. When a digital archiving system has to normalize the orientation of legacy PSD artwork and store the results in a lossless PNG format.
 * 5. When a CI/CD pipeline should validate and deskew PSD assets during build time and generate PNG assets for downstream applications.
 */
