// HOW-TO: How to Reduce PSD File Size Using RLE Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/optimized.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE
                };
                image.Save(outputPath, options);
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
 * 1. When you need to convert high‑resolution PNG assets to layered PSD files while keeping the output size low for faster uploads.
 * 2. When a web service must generate PSD previews from user‑uploaded PNGs and bandwidth constraints require RLE compression.
 * 3. When automating a design pipeline that stores intermediate images as PSD and you want to minimize disk usage without losing layer information.
 * 4. When integrating Aspose.Imaging in a C# application to export PNG graphics to PSD for Photoshop compatibility while optimizing storage.
 * 5. When building a batch‑processing tool that processes many PNG files into PSDs and you need to ensure each file is compressed using RLE to reduce overall archive size.
 */
