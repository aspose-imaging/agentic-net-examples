using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options (default settings)
                PngOptions pngOptions = new PngOptions();

                // Save the image as PNG to the specified output path
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy BMP files to PNG for smaller web‑friendly assets in a C# web application.
 * 2. When an automated build script must generate PNG thumbnails from BMP source images before publishing a product catalog.
 * 3. When a desktop utility has to ensure that user‑uploaded BMP pictures are saved in lossless PNG format for archival compliance.
 * 4. When a migration tool processes a folder of BMP scans and stores them as PNG to maintain compatibility with modern imaging libraries.
 * 5. When a reporting service creates PNG charts from BMP templates to embed in PDF documents generated with Aspose.PDF.
 */