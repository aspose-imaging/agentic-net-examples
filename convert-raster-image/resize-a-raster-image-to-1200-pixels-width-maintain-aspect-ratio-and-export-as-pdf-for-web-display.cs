// HOW-TO: Resize Image to 1200px Width and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\source.jpg";
        string outputPath = @"C:\Images\ResizedOutput.pdf";

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

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Desired width
                int targetWidth = 1200;

                // Calculate proportional height
                int targetHeight = (int)Math.Round((double)image.Height * targetWidth / image.Width);

                // Resize while preserving aspect ratio
                image.Resize(targetWidth, targetHeight, ResizeType.HighQualityResample);

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the resized image as PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a web‑friendly PDF from a high‑resolution JPEG by scaling it to a fixed width for faster page load.
 * 2. When an e‑commerce site must display product photos in PDF catalogs with consistent width while preserving the original aspect ratio.
 * 3. When a reporting tool creates printable PDFs from user‑uploaded images and requires automatic resizing to fit standard page layouts.
 * 4. When a content management system converts uploaded raster images to PDFs for archival, ensuring each file is no wider than 1200 pixels.
 * 5. When a mobile app backend prepares image‑based PDFs for email attachments, resizing them to reduce file size without distortion.
 */
