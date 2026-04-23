using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.pdf";

        // Validate input file existence
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
            // Configure PDF options with compression to reduce file size
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.PdfCoreOptions = new PdfCoreOptions
                {
                    // Use Flate compression (good balance of size and speed)
                    Compression = PdfImageCompressionOptions.Flate
                };

                // Optionally omit metadata to further reduce size
                pdfOptions.KeepMetadata = false;

                // Save the image as PDF with the specified options
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}