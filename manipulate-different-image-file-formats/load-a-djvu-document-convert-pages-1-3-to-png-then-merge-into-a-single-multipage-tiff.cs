using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\Temp\sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output paths
            string pngOutputDir = @"C:\Temp\output\png";
            string tiffOutputPath = @"C:\Temp\output\merged.tif";

            // Ensure output directories exist
            Directory.CreateDirectory(pngOutputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(tiffOutputPath));

            // Load DjVu document
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Convert pages 1‑3 to PNG
                for (int i = 0; i < 3 && i < djvuImage.PageCount; i++)
                {
                    var page = djvuImage.Pages[i];
                    string pngPath = Path.Combine(pngOutputDir, $"page{i + 1}.png");
                    // Save each page as PNG
                    page.Save(pngPath, new PngOptions());
                }

                // Merge pages 1‑3 into a single multipage TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                tiffOptions.BitsPerSample = new ushort[] { 1 };
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();
                tiffOptions.MultiPageOptions.Pages = new int[] { 0, 1, 2 };
                tiffOptions.MultiPageOptions.PageTitles = new string[] { "Page 1", "Page 2", "Page 3" };

                djvuImage.Save(tiffOutputPath, tiffOptions);
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
 * 1. When a document management system needs to extract the first three pages of a scanned DjVu file and provide them as high‑resolution PNG thumbnails for web preview.
 * 2. When an archival workflow requires converting selected DjVu pages to lossless PNG images before bundling them into a single multipage TIFF for long‑term storage with Deflate compression.
 * 3. When a legal e‑discovery tool must programmatically render specific DjVu pages as PNG files for OCR processing while also creating a combined TIFF file that preserves page order and titles.
 * 4. When a publishing platform wants to generate printable multipage TIFFs from the initial pages of a DjVu manuscript while also offering separate PNG assets for each page to be displayed in a mobile app.
 * 5. When an automated batch job processes incoming DjVu contracts, extracts pages 1‑3 as PNG for quick visual checks and merges them into a single TIFF to be attached to an email report.
 */