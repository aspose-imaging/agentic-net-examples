using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Configure PDF conversion options
            var pdfOptions = new PdfOptions
            {
                // Set compression to Flate for good balance between size and quality
                PdfCoreOptions = new PdfCoreOptions
                {
                    Compression = PdfImageCompressionOptions.Flate,
                    // Adjust JPEG quality for rasterized content (if any)
                    JpegQuality = 85
                }
            };

            // Save the image as PDF using the configured options
            image.Save(outputPath, pdfOptions);
        }
    }
}