using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with compression
                using (var pdfOptions = new PdfOptions())
                {
                    var coreOptions = new PdfCoreOptions
                    {
                        // Use Flate compression for smaller PDF size
                        Compression = PdfImageCompressionOptions.Flate,
                        // Optionally, do not keep original metadata to reduce size
                        // KeepMetadata = false
                    };

                    pdfOptions.PdfCoreOptions = coreOptions;

                    // Save the image as PDF with the specified options
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}