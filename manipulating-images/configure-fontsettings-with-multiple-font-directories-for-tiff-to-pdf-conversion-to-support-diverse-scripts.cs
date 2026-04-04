using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure multiple font directories for rendering
        string[] fontFolders = new string[]
        {
            "Fonts/Latin",
            "Fonts/Arabic",
            "Fonts/Chinese"
        };
        // Set font folders and clear cached fonts
        FontSettings.SetFontsFolders(fontFolders, true);

        // Load the TIFF image and convert to PDF
        using (Image image = Image.Load(inputPath))
        {
            var pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}