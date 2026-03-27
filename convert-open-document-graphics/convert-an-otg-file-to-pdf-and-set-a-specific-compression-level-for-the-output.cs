using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG
            var otgRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set PDF save options with desired compression
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = otgRasterizationOptions,
                PdfCoreOptions = new PdfCoreOptions
                {
                    // Example: use Flate compression for images inside the PDF
                    Compression = PdfImageCompressionOptions.Flate
                }
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}