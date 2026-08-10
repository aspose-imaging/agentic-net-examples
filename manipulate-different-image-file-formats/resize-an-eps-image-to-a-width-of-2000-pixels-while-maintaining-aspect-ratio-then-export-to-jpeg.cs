// HOW-TO: Resize EPS Image to 2000 Pixels Width and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\source.eps";
            string outputPath = @"C:\Images\ResizedResult.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate new height to keep aspect ratio
                int targetWidth = 2000;
                int targetHeight = (int)Math.Round((double)image.Height * targetWidth / image.Width);

                // Resize using a high‑quality interpolation method
                image.Resize(targetWidth, targetHeight, ResizeType.Mitchell);

                // Save as JPEG
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When a marketing system needs to generate web‑ready JPEG thumbnails from high‑resolution EPS logos while preserving the original proportions.
 * 2. When an e‑commerce platform must convert vector product illustrations to fixed‑width JPEGs for faster page loading.
 * 3. When a print‑to‑web workflow requires scaling EPS artwork to a 2000‑pixel width before embedding it in HTML emails.
 * 4. When a desktop application automates batch processing of EPS files, resizing them to a standard width and saving them as JPEG for archival.
 * 5. When a content management system needs to display user‑uploaded EPS diagrams as JPEG previews without distorting their aspect ratio.
 */
