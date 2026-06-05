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
            // Hardcoded input DjVu file path
            string inputPath = @"C:\temp\sample.djvu";

            // Hardcoded output directory for TIFF files
            string outputDir = @"C:\temp\output\";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the DjVu file stream and load the image
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Lzw;

                // Iterate through each page and save as a separate TIFF file
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.tif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as TIFF using the specified options
                    page.Save(outputPath, tiffOptions);
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
 * 1. When a legal firm needs to convert scanned DjVu case files into separate LZW‑compressed TIFF images for archival in a document management system.
 * 2. When a publishing company wants to split a multi‑page DjVu manuscript into individual high‑quality TIFF pages for further editing in Photoshop.
 * 3. When a government agency must extract each page of a DjVu map collection and save them as lossless TIFF files to meet GIS data standards.
 * 4. When a medical records department requires converting DjVu patient charts into separate TIFF images with LZW compression for secure storage in a PACS server.
 * 5. When an e‑learning platform needs to break down DjVu lecture notes into page‑by‑page TIFF files to generate thumbnails and support offline PDF generation.
 */