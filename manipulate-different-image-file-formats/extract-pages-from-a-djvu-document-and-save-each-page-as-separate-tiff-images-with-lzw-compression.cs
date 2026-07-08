using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.djvu";
            string outputDir = @"c:\temp\output\";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

            // Load DjVu image from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare TIFF save options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Lzw;

                // Iterate through each page and save as separate TIFF file
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.tif");

                    // Ensure directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as TIFF with the specified options
                    djvuPage.Save(outputPath, tiffOptions);
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
 * 1. When a legal firm needs to convert scanned multi‑page DjVu case files into separate LZW‑compressed TIFF images for archival in a document management system.
 * 2. When a publishing company wants to split a DjVu manuscript into individual high‑quality TIFF pages for further editing in Photoshop.
 * 3. When a government agency must extract each page of a DjVu technical manual and store them as compressed TIFFs to meet file‑size limits for secure file transfer.
 * 4. When a medical records system requires converting DjVu patient scans into separate TIFF files with lossless LZW compression for compatibility with legacy PACS software.
 * 5. When an e‑learning platform needs to break down DjVu lecture notes into individual TIFF images to generate thumbnails and enable page‑by‑page navigation on the website.
 */