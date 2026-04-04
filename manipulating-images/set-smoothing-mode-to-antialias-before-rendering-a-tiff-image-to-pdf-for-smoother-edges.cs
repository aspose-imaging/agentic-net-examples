using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF save options with anti‑alias smoothing
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    // Apply anti‑aliasing for smoother edges
                    SmoothingMode = SmoothingMode.AntiAlias,
                    // Use the original image size as the PDF page size
                    PageSize = image.Size,
                    // Optional: set a background color
                    BackgroundColor = Color.White
                }
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}