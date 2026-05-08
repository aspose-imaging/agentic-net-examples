using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input JPEG file paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\img1.jpg",
                @"C:\Images\img2.jpg",
                @"C:\Images\img3.jpg"
            };

            // Hardcoded output PDF file path
            string outputPath = @"C:\Images\merged.pdf";

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // List to hold cropped images
            List<Image> croppedImages = new List<Image>();

            // Load each JPEG, crop to central square, and store
            foreach (var inputPath in inputPaths)
            {
                // Load JPEG image
                JpegImage jpeg = new JpegImage(inputPath);

                // Determine size of central square
                int side = Math.Min(jpeg.Width, jpeg.Height);
                int x = (jpeg.Width - side) / 2;
                int y = (jpeg.Height - side) / 2;
                var cropRect = new Rectangle(x, y, side, side);

                // Crop in place
                jpeg.Crop(cropRect);

                // Add to collection
                croppedImages.Add(jpeg);
            }

            // Create a multipage image from the cropped squares
            Image merged = Image.Create(croppedImages.ToArray());

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save merged image as PDF
            var pdfOptions = new PdfOptions();
            merged.Save(outputPath, pdfOptions);

            // Dispose resources
            merged.Dispose();
            foreach (var img in croppedImages)
            {
                img.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}