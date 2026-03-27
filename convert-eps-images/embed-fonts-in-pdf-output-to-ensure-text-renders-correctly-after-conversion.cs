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
        string inputPath = "input.svg";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set the folder that contains the fonts to be embedded
        string fontsFolder = "fonts";
        FontSettings.SetFontsFolder(fontsFolder);
        // Update the internal font cache (required for some formats)
        FontSettings.UpdateFonts();

        // Load the source image (any vector format supported by Aspose.Imaging)
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF options (default options are sufficient for embedding fonts)
            var pdfOptions = new PdfOptions
            {
                // Example: set PDF/A-1b compliance if needed
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the image as PDF; fonts from the specified folder will be embedded
            image.Save(outputPath, pdfOptions);
        }
    }
}