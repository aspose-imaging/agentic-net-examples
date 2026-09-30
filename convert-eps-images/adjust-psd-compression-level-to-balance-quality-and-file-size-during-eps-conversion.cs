// HOW-TO: Convert EPS to PSD with RLE Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE
                };
                image.Save(outputPath, psdOptions);
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
 * 1. When a designer needs to export vector EPS artwork to a layered PSD file while keeping file size low by using RLE compression.
 * 2. When an automated build pipeline processes incoming EPS assets and converts them to PSD for Photoshop editing with balanced quality and storage.
 * 3. When a web service receives EPS logos and must generate PSD previews that are efficiently compressed for faster download.
 * 4. When migrating legacy EPS files to a Photoshop‑compatible format in a C# application and you want to control compression to avoid bloated PSD files.
 * 5. When integrating Aspose.Imaging into a C# workflow to batch‑convert EPS documents to PSD with RLE compression for archival purposes.
 */
