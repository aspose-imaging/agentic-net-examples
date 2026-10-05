// HOW-TO: Convert EMF to TIFF with LZW Compression Using MemoryStream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output/output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var ms = new MemoryStream(File.ReadAllBytes(inputPath)))
            {
                using (Image image = Image.Load(ms))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When you need to embed a vector EMF logo into a lossless TIFF document for archival purposes.
 * 2. When a reporting system generates charts as EMF files and you must convert them to TIFF for compatibility with legacy printers.
 * 3. When you want to compress large EMF drawings into smaller LZW‑compressed TIFF files to reduce storage costs.
 * 4. When processing EMF images received over a network stream and saving them as TIFF without writing the original file to disk.
 * 5. When automating batch conversion of EMF assets to TIFF in a C# application that requires the LZW compression option for TIFF compliance.
 */
