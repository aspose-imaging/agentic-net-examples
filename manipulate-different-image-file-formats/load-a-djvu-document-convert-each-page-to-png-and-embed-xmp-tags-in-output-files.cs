// HOW-TO: Convert DjVu Pages to PNG Images Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from stream
                using (DjvuImage djvuImage = (DjvuImage)Image.Load(stream))
                {
                    // Iterate through each page
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        PngOptions pngOptions = new PngOptions();
                        page.Save(outputPath, pngOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as separate PNG files for web preview or further processing.
 * 2. When automating a document workflow that converts scanned DjVu archives into high‑resolution PNG images for inclusion in a digital library.
 * 3. When building a C# application that must programmatically read DjVu streams and generate PNG thumbnails for each page.
 * 4. When migrating legacy DjVu documents to a more widely supported format like PNG to ensure compatibility with modern browsers and image editors.
 * 5. When creating a batch conversion tool that processes DjVu files from a folder, creates PNG outputs, and organizes them into a structured directory hierarchy.
 */
