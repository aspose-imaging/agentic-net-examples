// HOW-TO: Convert JPEG to TIFF with LZW Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "Output\\result.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.Compression = TiffCompressions.Lzw;
                    image.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive high‑resolution photographs in a lossless TIFF file while keeping file size low by using LZW compression.
 * 2. When a document‑management system requires images in TIFF format for compatibility and you must convert incoming JPEG scans efficiently.
 * 3. When preparing images for printing workflows that only accept TIFF files with LZW compression to preserve quality and reduce storage.
 * 4. When migrating a legacy medical‑imaging database that stores images as JPEGs to a TIFF‑based PACS that mandates LZW‑compressed files.
 * 5. When implementing a C# service that receives user‑uploaded JPEGs and stores them as compressed TIFFs for long‑term cloud storage.
 */
