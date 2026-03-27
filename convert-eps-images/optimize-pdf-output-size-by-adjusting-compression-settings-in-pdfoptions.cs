using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.png";
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
        // Create PDF options with compression settings
        using (PdfOptions pdfOptions = new PdfOptions())
        {
            // Set PDF core compression to Flate for smaller size
            pdfOptions.PdfCoreOptions = new PdfCoreOptions
            {
                Compression = PdfImageCompressionOptions.Flate
            };

            // Save the image as PDF using the configured options
            image.Save(outputPath, pdfOptions);
        }
    }
}