using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\input.webp";
        string outputPath = "C:\\temp\\output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Read the WebP image into a byte array
            byte[] imageBytes = File.ReadAllBytes(inputPath);

            // Load the image from the byte array using a MemoryStream
            using (var memoryStream = new MemoryStream(imageBytes))
            using (Image image = Image.Load(memoryStream))
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image as PDF
                image.Save(outputPath, new PdfOptions());
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
 * 1. When a web service receives a WebP image as a byte array from an HTTP request and must generate a PDF report for download.
 * 2. When a desktop application needs to convert user‑uploaded WebP screenshots stored in memory directly to a printable PDF without writing intermediate files.
 * 3. When an automated batch job processes a folder of WebP assets, reads each file into a byte array, and archives them as PDF documents for compliance.
 * 4. When a cloud function receives WebP image data from a message queue, loads it from a MemoryStream, and saves it as a PDF to a storage bucket.
 * 5. When a mobile backend API transforms WebP thumbnails captured on devices into PDF invoices that include the image as a visual element.
 */