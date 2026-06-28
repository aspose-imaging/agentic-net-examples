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
            string outputDirectory = @"c:\temp\";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (in case it's null, Path.GetDirectoryName returns null, so guard)
            Directory.CreateDirectory(outputDirectory);

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Prepare TIFF save options with Deflate compression
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Deflate;

                    // Iterate through each page and save as individual TIFF files
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"sample_page_{page.PageNumber}.tif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the current page as TIFF using the specified options
                        page.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert multi‑page DjVu archives of scanned documents into individual high‑quality TIFF files with lossless Deflate compression for archival storage.
 * 2. When an application must extract each page from a DjVu e‑book and save them as separate TIFF images to be processed later by OCR engines that only accept TIFF input.
 * 3. When a workflow requires batch conversion of DjVu blueprints into TIFF files with Deflate compression to reduce file size while preserving vector detail for CAD integration.
 * 4. When a document management system imports DjVu files and needs to generate TIFF thumbnails for each page using C# and Aspose.Imaging to display previews in a web portal.
 * 5. When a developer is building a migration tool that reads DjVu files, applies custom TiffOptions, and outputs per‑page TIFFs to comply with a regulatory format that mandates TIFF with Deflate compression.
 */