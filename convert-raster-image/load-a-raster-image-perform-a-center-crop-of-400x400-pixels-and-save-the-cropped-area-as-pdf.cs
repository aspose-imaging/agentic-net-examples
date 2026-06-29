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
            string inputPath = @"C:\Images\input.jpg";
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
                // Define a 400x400 centered rectangle
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;

                // Adjust if the source image is smaller than the crop size
                if (left < 0) left = 0;
                if (top < 0) top = 0;
                int actualWidth = Math.Min(cropWidth, image.Width);
                int actualHeight = Math.Min(cropHeight, image.Height);

                var area = new Rectangle(left, top, actualWidth, actualHeight);

                // Perform the crop
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
 * 1. When a developer needs to generate a PDF thumbnail of a product photo by extracting a centered 400 × 400 pixel region from a JPEG image.
 * 2. When an application must create a printable PDF preview of a scanned document by cropping the central area of a raster image before saving.
 * 3. When a web service processes user‑uploaded photos and must produce a fixed‑size PDF receipt by performing a center crop on the original image.
 * 4. When a batch job converts a collection of large JPEG files into PDF flyers with a consistent 400 × 400 px focus area for branding purposes.
 * 5. When a desktop utility needs to extract the main subject from a picture and store it as a PDF for archival or sharing, using C# image loading, cropping, and PdfOptions.
 */