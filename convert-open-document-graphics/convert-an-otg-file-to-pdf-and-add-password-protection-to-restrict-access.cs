using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image and convert to PDF
        using (Image image = Image.Load(inputPath))
        {
            // Set rasterization options for OTG
            var otgRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure PDF save options
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = otgRasterizationOptions
                // Password protection is not directly supported via PdfOptions in Aspose.Imaging.
                // If a future version adds such a feature, set the appropriate properties here.
            };

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}