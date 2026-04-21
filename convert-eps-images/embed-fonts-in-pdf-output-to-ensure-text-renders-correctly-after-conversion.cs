using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.pdf";
        string fontsFolder = "fonts";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure Aspose.Imaging to use custom fonts folder
        FontSettings.SetFontsFolder(fontsFolder);
        FontSettings.UpdateFonts();

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF save options
            var pdfOptions = new PdfOptions
            {
                // Example: set PDF compliance if needed
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.Pdf15
                }
            };

            // Save the image as PDF with embedded fonts
            image.Save(outputPath, pdfOptions);
        }
    }
}