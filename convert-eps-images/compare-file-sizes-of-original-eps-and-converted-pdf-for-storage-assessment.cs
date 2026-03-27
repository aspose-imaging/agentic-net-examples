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
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? ".");

        // Load the EPS image
        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Set up PDF conversion options (default compliance)
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions()
                // Additional options can be set here if needed
            };

            // Save the image as PDF
            epsImage.Save(outputPath, pdfOptions);
        }

        // Retrieve file sizes
        long epsSize = new FileInfo(inputPath).Length;
        long pdfSize = new FileInfo(outputPath).Length;

        // Output the size comparison
        Console.WriteLine($"EPS file size: {epsSize} bytes");
        Console.WriteLine($"PDF file size: {pdfSize} bytes");
        Console.WriteLine($"Size difference: {pdfSize - epsSize} bytes");
    }
}