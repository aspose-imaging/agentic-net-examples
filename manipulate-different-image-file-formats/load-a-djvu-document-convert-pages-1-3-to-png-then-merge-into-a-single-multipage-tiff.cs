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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.djvu";
            string pngOutputDir = @"C:\temp\pngs";
            string tiffOutputPath = @"C:\temp\merged.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(pngOutputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(tiffOutputPath));

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Convert pages 1‑3 to PNG
                int pagesToConvert = Math.Min(3, djvuImage.PageCount);
                for (int i = 0; i < pagesToConvert; i++)
                {
                    var page = djvuImage.Pages[i];
                    string pngPath = Path.Combine(pngOutputDir, $"page{i + 1}.png");
                    // Ensure directory for each PNG (already created above)
                    page.Save(pngPath, new PngOptions());
                }

                // Merge the first three pages into a single multipage TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Deflate,
                    BitsPerSample = new ushort[] { 1 },
                    MultiPageOptions = new DjvuMultiPageOptions()
                };
                // Specify pages to include (zero‑based indices)
                tiffOptions.MultiPageOptions.Pages = new int[] { 0, 1, 2 };

                // Save the multipage TIFF
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
 * 1. When a developer needs to extract the first three pages of a scanned DjVu archive and provide them as high‑resolution PNG files for web preview.
 * 2. When a document‑management system must convert selected DjVu pages into a single multipage TIFF for archival storage with lossless Deflate compression.
 * 3. When an e‑learning platform wants to generate printable PNG images of the initial DjVu chapters while also creating a combined TIFF for batch printing.
 * 4. When a legal‑tech application requires converting specific DjVu pages to PNG for OCR processing and then merging them into a TIFF to maintain page order in a case file.
 * 5. When a desktop utility automates the transformation of a DjVu user manual’s first three pages into PNG thumbnails and a consolidated TIFF for inclusion in a product support package.
 */