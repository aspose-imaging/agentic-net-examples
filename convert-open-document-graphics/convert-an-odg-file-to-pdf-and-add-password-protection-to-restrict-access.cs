using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.odg";
        string outputPath = @"C:\Data\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for ODG to PDF conversion
            OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size
            };

            // Configure PDF save options
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Embed a digital signature (password protection) into the image
            // The password can be any string; here we use a hardcoded example
            const string password = "SecretPassword123";
            if (image is RasterCachedMultipageImage cachedImage)
            {
                cachedImage.EmbedDigitalSignature(password);
            }

            // Save the image as PDF with the specified options
            image.Save(outputPath, pdfOptions);
        }
    }
}