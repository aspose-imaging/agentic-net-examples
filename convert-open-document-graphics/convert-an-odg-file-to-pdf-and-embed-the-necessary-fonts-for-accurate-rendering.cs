using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\input\sample.odg";
            string outputPath = @"C:\output\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Optional: set custom fonts folder to ensure required fonts are available
            // Here we use the system fonts folder; adjust as needed.
            string systemFontsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            Aspose.Imaging.FontSettings.SetFontsFolder(systemFontsFolder);
            Aspose.Imaging.FontSettings.UpdateFonts();

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for ODG
                OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Set up PDF save options and attach rasterization options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

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