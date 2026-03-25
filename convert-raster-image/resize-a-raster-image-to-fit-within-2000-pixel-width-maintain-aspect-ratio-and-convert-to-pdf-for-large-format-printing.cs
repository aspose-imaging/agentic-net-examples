using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\SourceImage.jpg";
        string outputPath = @"C:\Images\Output\ResizedDocument.pdf";

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
            // Determine the target width (max 2000 px) while preserving aspect ratio
            int targetWidth = Math.Min(image.Width, 2000);
            int targetHeight = (int)Math.Round((double)image.Height * targetWidth / image.Width);

            // Resize the image using a high‑quality resampling algorithm
            image.Resize(targetWidth, targetHeight, ResizeType.HighQualityResample);

            // Prepare PDF export options
            var pdfOptions = new PdfOptions
            {
                // Optional: keep original DPI if required
                UseOriginalImageResolution = true
            };

            // Save the resized image as a PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}