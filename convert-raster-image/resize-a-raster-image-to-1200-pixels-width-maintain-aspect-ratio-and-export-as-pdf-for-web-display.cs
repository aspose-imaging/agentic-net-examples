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
            string inputPath = @"C:\Images\source.jpg";
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
                // Calculate new height to maintain aspect ratio
                int newWidth = 1200;
                int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

                // Resize the image
                image.Resize(newWidth, newHeight);

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
 * 1. When a web developer needs to generate a PDF thumbnail of a high‑resolution JPEG for faster page load, they can resize the raster image to a 1200‑pixel width while preserving aspect ratio and export it as PDF using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform wants to create printable product catalogs from user‑uploaded photos, the code can resize each image to a consistent width and convert it to PDF for consistent layout.
 * 3. When a content management system must automatically produce PDF previews of uploaded images for SEO‑friendly indexing, the snippet resizes the source image and saves it as a PDF document.
 * 4. When a digital marketing agency needs to batch‑process campaign assets, converting large JPEG banners into 1200‑pixel‑wide PDFs ensures uniform size for email newsletters.
 * 5. When a desktop application offers a “Save as PDF” feature for image files, this code provides the logic to maintain the original aspect ratio while scaling the image to a web‑ready width before saving.
 */