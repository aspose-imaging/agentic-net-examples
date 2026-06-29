using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Define a 200x200 rectangle centered in the image
                int cropWidth = 200;
                int cropHeight = 200;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                var area = new Rectangle(left, top, cropWidth, cropHeight);

                // Crop the image
                image.Crop(area);

                // Save the cropped image as PDF
                var pdfOptions = new PdfOptions();
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
 * 1. When a developer needs to generate a printable PDF thumbnail of a user‑uploaded PNG by extracting a 200 × 200 region from the image’s center.
 * 2. When an e‑commerce platform wants to create a centered preview PDF of product photos for catalog PDFs without loading the entire image into memory.
 * 3. When a document management system must convert scanned raster pages into PDF files that contain only the central area of interest for compliance reports.
 * 4. When a mobile app backend processes profile pictures, cropping the middle 200 × 200 pixels and saving the result as a PDF for archival storage.
 * 5. When a reporting tool automatically extracts a centered square from high‑resolution PNG charts and embeds it as a PDF page for inclusion in generated reports.
 */