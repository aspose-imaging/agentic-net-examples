using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Data\sample.odg";
        string outputPath = @"C:\Data\Result\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Optional: specify custom fonts folder to embed fonts during rasterization
        // Adjust the path to a folder that contains the required TrueType fonts
        string fontsFolder = @"C:\Windows\Fonts";
        FontSettings.SetFontsFolder(fontsFolder);
        FontSettings.UpdateFonts();

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for ODG
            OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size // Preserve original page size
            };

            // Set up PDF save options and attach rasterization options
            PdfOptions pdfSaveOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the image as PDF with embedded fonts
            image.Save(outputPath, pdfSaveOptions);
        }
    }
}