using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf; // For PdfCoreOptions if needed

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options
            var pdfOptions = new PdfOptions();

            // Optional: set PDF compliance version
            // pdfOptions.PdfCoreOptions = new PdfCoreOptions
            // {
            //     PdfCompliance = PdfComplianceVersion.Pdf15
            // };

            // Save the image as a PDF preserving fidelity
            image.Save(outputPath, pdfOptions);
        }
    }
}