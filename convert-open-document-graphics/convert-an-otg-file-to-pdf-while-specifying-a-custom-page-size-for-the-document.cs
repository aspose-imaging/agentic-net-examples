using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded relative input and output paths
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

        // Load the OTG image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Configure OTG rasterization options with a custom page size
            var otgOptions = new OtgRasterizationOptions
            {
                // Example custom size: 800x600 points
                PageSize = new Aspose.Imaging.SizeF(800, 600),
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Set up PDF save options and assign the rasterization options
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = otgOptions
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}