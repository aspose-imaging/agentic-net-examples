// HOW-TO: Convert DjVu Document to Multi‑Page Deflate TIFF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffDeflateRgb);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
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
 * 1. When a developer needs to archive scanned books stored as DjVu by converting each page to a lossless Deflate‑compressed TIFF for long‑term preservation.
 * 2. When an application must extract individual pages from a DjVu file and save them as separate TIFF images for downstream OCR processing.
 * 3. When a workflow requires converting DjVu documents to TIFF format to ensure compatibility with legacy printing systems that only accept TIFF files.
 * 4. When a developer wants to reduce file size while keeping full color fidelity by using the TiffDeflateRgb option during DjVu‑to‑TIFF conversion in a .NET service.
 * 5. When a batch job processes multiple DjVu files and needs to generate a set of page‑wise TIFF files in a specified output folder using Aspose.Imaging for .NET.
 */
