// HOW-TO: Extract DjVu Pages to Separate LZW Compressed TIFF Files in C# (Aspose.Imaging for .NET)
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
            Directory.CreateDirectory(outputDir);

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Prepare TIFF save options with LZW compression
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Lzw;

                    // Iterate through each page and save as separate TIFF
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        string outputPath = Path.Combine(outputDir, $"sample_page_{djvuPage.PageNumber}.tif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as TIFF
                        djvuPage.Save(outputPath, tiffOptions);
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
 * 1. When you need to convert each page of a scanned DjVu archive into individual TIFF images for archival or printing, preserving lossless LZW compression.
 * 2. When a document workflow requires splitting a multi‑page DjVu file into separate TIFF files to feed into OCR or image analysis pipelines.
 * 3. When integrating legacy DjVu documents into a .NET application that only supports TIFF, you can extract pages and save them with LZW compression for compatibility.
 * 4. When preparing DjVu pages for inclusion in a PDF or Word report, converting each page to a high‑quality TIFF ensures consistent rendering across platforms.
 * 5. When automating batch processing of DjVu files on a server, this code extracts pages and stores them as compressed TIFFs to reduce storage while maintaining image fidelity.
 */
