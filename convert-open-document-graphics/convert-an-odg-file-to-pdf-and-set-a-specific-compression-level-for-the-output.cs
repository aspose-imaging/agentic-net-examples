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
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample.pdf";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PDF save options with desired compression
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Example compression setting; adjust as needed
                        Compression = PdfImageCompressionOptions.Flate
                    }
                };

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}