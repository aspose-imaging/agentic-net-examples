// HOW-TO: Convert Odd Pages of DjVu to TIFF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvuImage.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    // Zero‑based index: even i corresponds to odd‑numbered pages (1,3,5,…)
                    if (i % 2 != 0) continue;

                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(i, i));
                        djvuImage.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to extract only the odd‑numbered pages from a multi‑page DjVu file and save them as separate TIFF images for archival or printing.
 * 2. When an application must generate TIFF files for every other page of a scanned DjVu document to reduce file size while preserving key pages for downstream OCR processing.
 * 3. When a workflow requires converting specific pages (e.g., page 1, 3, 5) of a DjVu e‑book into TIFF format for compatibility with legacy imaging systems.
 * 4. When a batch job processes a folder of DjVu files and needs to export only the odd pages as TIFFs to meet a client’s document‑exchange specification.
 * 5. When a developer wants to use Aspose.Imaging’s IntRange selection to programmatically save selected DjVu pages as multi‑page TIFFs for selective document sharing.
 */
