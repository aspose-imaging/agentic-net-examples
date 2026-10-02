// HOW-TO: Convert DjVu Document Pages To Deflate Compressed TIFF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\document.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tiff");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffDeflateRgb))
                    {
                        tiffOptions.Compression = TiffCompressions.Deflate;
                        djvu.Pages[i].Save(outputPath, tiffOptions);
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
 * 1. When you need to archive scanned DjVu files as separate TIFF images with Deflate compression to reduce storage size while preserving image quality.
 * 2. When a legacy document workflow requires each page of a DjVu document to be saved as an individual TIFF for compatibility with older systems.
 * 3. When preparing DjVu pages for an OCR engine that only accepts TIFF input, using Deflate compression to speed up processing and lower memory usage.
 * 4. When generating printable TIFF files from DjVu source material while keeping color information and minimizing file size for faster web delivery.
 * 5. When converting multi‑page DjVu manuals into individual TIFF pages for integration into a .NET reporting tool that consumes TIFF images.
 */
