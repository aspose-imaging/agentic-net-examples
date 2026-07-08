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
            string inputPath = @"c:\temp\sample.djvu";
            string pngOutputPattern = @"c:\temp\sample.{0}.png";
            string tiffOutputPath = @"c:\temp\sample.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists for TIFF
            Directory.CreateDirectory(Path.GetDirectoryName(tiffOutputPath));

            // Open DjVu image from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Convert pages 1‑3 (indices 0‑2) to PNG
                for (int i = 0; i < 3 && i < djvuImage.PageCount; i++)
                {
                    string pngPath = string.Format(pngOutputPattern, i + 1);
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                    djvuImage.Pages[i].Save(pngPath, new PngOptions());
                }

                // Prepare TIFF save options with multi‑page settings for pages 1‑3
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Deflate,
                    BitsPerSample = new ushort[] { 1 },
                    MultiPageOptions = new DjvuMultiPageOptions()
                };
                tiffOptions.MultiPageOptions.Pages = new int[] { 0, 1, 2 };
                tiffOptions.MultiPageOptions.PageTitles = new string[] { "Page 1", "Page 2", "Page 3" };

                // Save as multipage TIFF
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
 * 1. When a developer needs to extract the first three pages of a DjVu document as PNG images for web preview while also creating a single Deflate‑compressed multipage TIFF for archival storage.
 * 2. When an application must generate PNG thumbnails of selected DjVu pages for a document management system and simultaneously bundle those pages into a compressed TIFF for printing workflows.
 * 3. When a legal‑tech solution requires converting the opening pages of a DjVu case file into PNG for OCR processing and then merging them into a titled multipage TIFF to be included in a court‑ready PDF package.
 * 4. When a digital library wants to serve the first three pages of a DjVu e‑book as PNG files for quick browsing and also provide a downloadable multipage TIFF that preserves page order and titles.
 * 5. When a batch‑processing script automates the transformation of DjVu manuals into PNG assets for mobile apps and creates a consolidated TIFF with Deflate compression to reduce cloud storage costs.
 */