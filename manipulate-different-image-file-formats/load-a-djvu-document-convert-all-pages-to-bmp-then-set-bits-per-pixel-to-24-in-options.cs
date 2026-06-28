using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\temp\sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory
            string outputDir = @"C:\temp\output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load DjVu document from stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set BMP save options with 24 bits per pixel
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
                    };

                    // Save the page as BMP using the specified options
                    page.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and generate high‑quality 24‑bit BMP images for archival or printing purposes.
 * 2. When an application must convert scanned DjVu files into BMP format to feed legacy Windows imaging tools that only accept 24‑bit BMP files.
 * 3. When a batch‑processing service has to read DjVu files from a file stream, iterate over all pages, and save them as BMP images with a specific BitsPerPixel setting for consistent color depth.
 * 4. When a document‑management system requires converting DjVu pages to BMP thumbnails with 24‑bit color to ensure accurate visual representation in a .NET environment.
 * 5. When a developer wants to automate the conversion of DjVu pages to BMP using Aspose.Imaging for .NET while handling missing files and creating output directories programmatically.
 */