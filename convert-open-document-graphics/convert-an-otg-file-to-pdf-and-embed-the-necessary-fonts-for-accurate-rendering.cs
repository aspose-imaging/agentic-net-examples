using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\input\sample.otg";
            string outputPath = @"C:\output\sample.pdf";

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
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size // Preserve original size
                };

                // Set up PDF save options and attach rasterization options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Optional: enforce PDF/A compliance to embed fonts
                // pdfOptions.PdfCoreOptions = new PdfCoreOptions
                // {
                //     PdfCompliance = PdfComplianceVersion.PdfA1b
                // };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}