using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.tiff";
            string outputPath = @"C:\Output\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure multiple font directories (add as needed)
            string[] fontFolders = new string[]
            {
                @"C:\Fonts\Latin",
                @"C:\Fonts\CJK",
                @"C:\Fonts\Arabic"
            };
            // Set the font folders and enable recursive search
            FontSettings.SetFontsFolders(fontFolders, true);

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}