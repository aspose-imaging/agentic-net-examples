using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.fodg";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure font substitution
        // Folder that contains replacement fonts (must exist and contain .ttf files)
        string substituteFontsFolder = "fonts";
        Aspose.Imaging.FontSettings.SetFontsFolder(substituteFontsFolder);
        // Optional: set a default font name to use when a specific font is missing
        Aspose.Imaging.FontSettings.DefaultFontName = "Arial";

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for ODG to PDF conversion
            var rasterizationOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size
            };

            // Set up PDF save options using the rasterization options
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the image to PDF, missing fonts will be substituted
            image.Save(outputPath, pdfOptions);
        }
    }
}