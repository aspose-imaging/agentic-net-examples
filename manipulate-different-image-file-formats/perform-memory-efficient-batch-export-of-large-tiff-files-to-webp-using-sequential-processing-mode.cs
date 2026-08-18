// HOW-TO: Batch Export Large Multi‑Page TIFF to WebP Sequentially in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "large.tif");
            string outputDirectory = Path.Combine("Output");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the large TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Define the per-page processing action
                tiffImage.PageExportingAction = delegate (int index, Image page)
                {
                    // Cast the page to RasterImage for saving
                    RasterImage rasterPage = (RasterImage)page;

                    // Build output WebP file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{index}.webp");

                    // Ensure the directory for the output file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure WebP options (adjust quality as needed)
                    var webpOptions = new WebPOptions
                    {
                        Quality = 80 // Example quality setting
                    };

                    // Save the current page as a WebP image
                    rasterPage.Save(outputPath, webpOptions);
                };

                // Trigger sequential processing by saving to a temporary TIFF file
                string tempTiffPath = Path.Combine(outputDirectory, "temp.tif");
                Directory.CreateDirectory(Path.GetDirectoryName(tempTiffPath));
                tiffImage.Save(tempTiffPath);

                // Cleanup temporary file
                if (File.Exists(tempTiffPath))
                {
                    File.Delete(tempTiffPath);
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
 * 1. When you need to convert each page of a multi‑page TIFF archive into separate WebP files without loading the entire document into memory.
 * 2. When a web application must serve high‑resolution scanned documents as lightweight WebP images to improve page load speed.
 * 3. When processing large medical or satellite TIFF images on a server with limited RAM and you want to export them page by page.
 * 4. When automating a nightly batch job that transforms scanned PDFs saved as TIFFs into WebP for archival or CDN distribution.
 * 5. When integrating image conversion into a C# workflow that requires sequential processing to avoid out‑of‑memory exceptions.
 */
