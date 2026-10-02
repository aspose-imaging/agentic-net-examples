// HOW-TO: Convert DjVu Pages to Deflate Compressed TIFF Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.djvu");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    string outputPath = Path.Combine("Output", $"page_{i}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Deflate;

                    djvu.Pages[i].Save(outputPath, tiffOptions);
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
 * 1. When you need to archive scanned documents from a DjVu file as lossless TIFF images with smaller file size using Deflate compression.
 * 2. When a printing workflow requires each page of a multi‑page DjVu to be saved as an individual TIFF for compatibility with legacy RIP software.
 * 3. When you want to preprocess DjVu pages for OCR by converting them to TIFF format with Deflate compression to preserve quality while reducing storage.
 * 4. When a digital library system stores source DjVu files but serves TIFF images to users, and you need a C# routine to generate those TIFFs page by page.
 * 5. When an automated batch process must extract every page from a DjVu document and save them as separate TIFF files with consistent compression settings for downstream image analysis.
 */
