using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.jpg";
        string outputPath = "result.pdf";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Define the desired size (example: half the original dimensions)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize using Lanczos resampling for high‑quality results
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the resized image as a PDF document
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
 * 1. When a web application needs to generate a printable PDF from user‑uploaded JPEG photos while preserving visual quality, a developer can use this C# code to resize the image with Lanczos resampling and save it as a PDF.
 * 2. When an e‑commerce platform wants to create thumbnail‑size PDF catalogs from high‑resolution product images, the code provides a fast way to halve the dimensions with high‑quality Lanczos scaling before exporting to PDF.
 * 3. When a document management system must compress large scanned images into smaller PDF files for archival, the developer can apply Lanczos resampling in C# to reduce file size without noticeable loss and then save the result as a PDF.
 * 4. When a desktop utility needs to batch‑process photos into PDF slideshows, the sample shows how to programmatically load each raster image, resize it using Lanczos for sharpness, and convert it to a PDF document in .NET.
 * 5. When a mobile backend service receives raw JPEG uploads and must deliver a PDF preview to clients, this code demonstrates the C# workflow of verifying the file, resizing with Lanczos resample, and exporting to PDF for fast rendering.
 */