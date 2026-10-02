// HOW-TO: Adjust Gamma of TIFF Image to 1.2 and Export as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\image.tif";
        string outputPath = "Output\\adjusted.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.AdjustGamma(1.2f);

                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to brighten a scanned TIFF document by applying a 1.2 gamma correction and deliver the result as a PNG for web display.
 * 2. When a medical imaging workflow requires converting high‑resolution TIFF scans to PNG while adjusting gamma to improve visual contrast.
 * 3. When an e‑commerce platform must preprocess product photos stored as TIFF, apply gamma correction for consistent brightness, and store them as PNG thumbnails.
 * 4. When a desktop application automates batch processing of archival TIFF files, applying a 1.2 gamma curve before saving them in a lossless PNG format.
 * 5. When a developer integrates Aspose.Imaging in a C# service to correct the gamma of satellite TIFF imagery and output the adjusted image as PNG for downstream analysis.
 */
