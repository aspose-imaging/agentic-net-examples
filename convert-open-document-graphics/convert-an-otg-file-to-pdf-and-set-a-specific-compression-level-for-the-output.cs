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
            // Configure rasterization options for OTG to PDF conversion
            OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set PDF-specific options, including compression level
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = otgRasterizationOptions,
                PdfCoreOptions = new PdfCoreOptions
                {
                    // Example compression: Flate
                    Compression = PdfImageCompressionOptions.Flate
                }
            };

            // Save the image as PDF with the specified options
            image.Save(outputPath, pdfOptions);
        }
    }
}