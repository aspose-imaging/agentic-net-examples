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
            // Input DjVu file path (relative)
            string inputPath = Path.Combine("Input", "sample.djvu");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Configure PNG options with a custom filter type
                    PngOptions pngOptions = new PngOptions
                    {
                        FilterType = PngFilterType.Sub // Example filter type
                    };

                    // Iterate through each page and save as PNG
                    foreach (Image page in djvuImage.Pages)
                    {
                        // Cast to DjvuPage to access the page number
                        DjvuPage djvuPage = (DjvuPage)page;
                        string outputPath = Path.Combine("Output", $"page_{djvuPage.PageNumber}.png");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG using the custom options
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and generate high‑quality PNG images with a specific PNG filter (e.g., Sub) for downstream web publishing.
 * 2. When an archival system must convert scanned DjVu files into lossless PNG files while preserving page numbers for indexing and search.
 * 3. When a digital library wants to provide thumbnail previews of DjVu books by converting every page to PNG using Aspose.Imaging in a C# batch process.
 * 4. When a document‑processing pipeline requires converting DjVu pages to PNG with custom compression settings to meet size constraints before uploading to cloud storage.
 * 5. When a developer is building a Windows service that monitors an Input folder, reads DjVu files, and automatically saves each page as PNG with chosen filter types for further image analysis.
 */