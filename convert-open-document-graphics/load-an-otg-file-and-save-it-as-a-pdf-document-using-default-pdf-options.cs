using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG
            OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
            {
                // Preserve original page size
                PageSize = image.Size
            };

            // Set up PDF save options with the rasterization options
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = otgRasterizationOptions
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}