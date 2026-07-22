using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.djvu";
            string outputPath = @"C:\Temp\odd_pages.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Collect odd‑numbered page indexes (0‑based: 0,2,4,...)
                List<int> oddPages = new List<int>();
                for (int i = 0; i < djvuImage.PageCount; i += 2)
                {
                    oddPages.Add(i);
                }

                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
                tiffOptions.Compression = Aspose.Imaging.FileFormats.Tiff.Enums.TiffCompressions.Deflate;
                tiffOptions.BitsPerSample = new ushort[] { 1 }; // optional B/W conversion

                // Specify only odd pages for export
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(oddPages.ToArray());

                // Save selected pages to TIFF
                djvuImage.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to extract only the odd‑numbered pages from a multi‑page DjVu document and save them as a compressed multi‑page TIFF for archival or printing.
 * 2. When an application must programmatically verify the existence of a DjVu file, create the output folder, and convert selected pages to a black‑and‑white TIFF using Deflate compression.
 * 3. When a document‑processing workflow requires converting every other page of a scanned DjVu book into a TIFF that can be consumed by legacy systems that only support TIFF.
 * 4. When a C# service automates batch conversion of DjVu documents, selecting only the first, third, fifth pages to reduce file size while preserving image quality.
 * 5. When a developer wants to use Aspose.Imaging’s DjvuMultiPageOptions to specify a custom page index array and generate a multi‑page TIFF with specific bits‑per‑sample settings.
 */