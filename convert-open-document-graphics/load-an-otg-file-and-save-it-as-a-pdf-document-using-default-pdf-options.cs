using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
            {
                // Preserve the original image size
                PageSize = image.Size
            };

            // Set up PDF save options and attach the rasterization options
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = otgOptions
            };

            // Save the image as a PDF file
            image.Save(outputPath, pdfOptions);
        }
    }
}