// HOW-TO: Center Crop a JPEG to 400x400 and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.pdf";

        try
        {
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
                // Determine the rectangle for a centered 400x400 crop
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                var cropArea = new Rectangle(left, top, cropWidth, cropHeight);

                // Perform the crop
                image.Crop(cropArea);

                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Save the cropped image as PDF
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
 * 1. When you need to generate a PDF thumbnail of a photo by extracting the central 400×400 region.
 * 2. When creating printable PDFs from scanned images and you want to focus on the image’s central area.
 * 3. When preparing a fixed‑size preview for a web gallery and the output must be a PDF document.
 * 4. When automating a workflow that extracts a centered square from product photos and stores it as PDF for archival.
 * 5. When converting high‑resolution JPEGs to smaller PDF files while preserving only the most important central content.
 */
