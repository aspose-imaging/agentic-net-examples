// HOW-TO: Convert DjVu Pages to PNG with Sub Filter Using C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputDirectory = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page and save as PNG with custom filter type
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Prepare output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PNG options with a custom filter type
                    PngOptions pngOptions = new PngOptions
                    {
                        FilterType = PngFilterType.Sub
                    };

                    // Save the page as PNG using the configured options
                    page.Save(outputPath, pngOptions);
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
 * 1. When you need to extract each page of a DjVu document as separate PNG files for web preview, you can use this code.
 * 2. When you want to apply a specific PNG filter (Sub) to reduce file size while preserving image quality during batch conversion of DjVu pages.
 * 3. When an application processes scanned books stored in DjVu format and must generate PNG thumbnails for each page on the fly.
 * 4. When integrating Aspose.Imaging into a C# service that converts multi‑page DjVu files into individual PNG images for further image analysis.
 * 5. When automating a workflow that reads DjVu files from a directory, creates an output folder, and saves each page as a PNG with custom compression settings.
 */
