// HOW-TO: Export PNG to PSD with RLE Compression Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/result.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                using (PsdOptions options = new PsdOptions())
                {
                    options.CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE;
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
 * 1. When you need to convert high‑resolution PNG assets to Photoshop PSD files while keeping lossless quality and reducing file size with RLE compression.
 * 2. When automating a batch workflow that prepares design files for Photoshop by exporting PNGs to PSDs with efficient RLE compression in a .NET application.
 * 3. When integrating image export functionality into a web service that delivers PSD files optimized for storage and bandwidth using Aspose.Imaging’s RLE compression.
 * 4. When preserving layer‑compatible PSD output from PNG sources for downstream editing in Photoshop, and you want to minimize the PSD’s disk footprint.
 * 5. When building a desktop tool that lets users save edited PNG graphics as PSDs with lossless RLE compression to meet Adobe file standards.
 */
