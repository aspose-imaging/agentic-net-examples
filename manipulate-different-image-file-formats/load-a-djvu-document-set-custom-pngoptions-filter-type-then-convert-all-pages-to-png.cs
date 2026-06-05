using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input DjVu file (relative path)
            string inputPath = "Input/sample.djvu";

            // Output directory for PNG pages
            string outputDirectory = "Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    int pageCount = djvuImage.PageCount;

                    // Iterate through all pages
                    for (int i = 0; i < pageCount; i++)
                    {
                        // Cast page to DjvuPage
                        DjvuPage djvuPage = (DjvuPage)djvuImage.Pages[i];

                        // Build output file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure PNG options with a custom filter type
                        PngOptions pngOptions = new PngOptions
                        {
                            FilterType = PngFilterType.Sub // example filter
                        };

                        // Save the page as PNG
                        djvuPage.Save(outputPath, pngOptions);
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
 * 1. When a document management system needs to archive scanned DjVu files as lossless PNG images for each page, developers can use this code to extract and save every page with a specific PNG filter for optimal compression.
 * 2. When an e‑learning platform wants to display DjVu lecture notes on web browsers that only support PNG, the code converts each DjVu page to PNG while applying a custom filter to improve rendering speed.
 * 3. When a legal firm must submit court evidence in PNG format and preserve the original page quality, developers can load the DjVu case file and export each page using the Sub filter to meet the required image standards.
 * 4. When a digital publishing workflow requires batch conversion of multi‑page DjVu comics into PNG assets for responsive design, this snippet automates the page‑by‑page extraction with a chosen PNG filter for consistent visual fidelity.
 * 5. When a medical imaging application needs to generate PNG thumbnails from multi‑page DjVu scans for quick preview in a C# UI, the code provides a straightforward way to read the DjVu stream, set a custom PNG filter, and save each page as a separate PNG file.
 */