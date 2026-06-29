using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.grayscale.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Apply grayscale filter
                pngImage.Grayscale();

                // Save the processed image
                pngImage.Save(outputPath);
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
 * 1. When a developer needs to convert color PNG screenshots to grayscale to reduce file size before uploading them to a web server using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform wants to display product thumbnail PNG images in grayscale for out‑of‑stock items by applying a grayscale filter in a .NET backend.
 * 3. When a batch processing job creates grayscale versions of scanned PNG documents to improve OCR accuracy, leveraging the Grayscale method of Aspose.Imaging in C#.
 * 4. When a server‑side service generates grayscale map tiles from PNG assets for a night‑mode UI, using C# file I/O and Aspose.Imaging’s grayscale filter.
 * 5. When a reporting tool automatically applies a grayscale filter to PNG charts before embedding them into PDF reports to comply with corporate visual guidelines.
 */