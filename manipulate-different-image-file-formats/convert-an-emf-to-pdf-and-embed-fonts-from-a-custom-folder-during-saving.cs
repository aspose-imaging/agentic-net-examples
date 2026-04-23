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
            // Hard‑coded input EMF file, output PDF file and custom fonts folder
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample.pdf";
            string fontsFolder = @"C:\CustomFonts";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Register the custom fonts folder so that missing fonts are resolved and embedded
            FontSettings.SetFontsFolder(fontsFolder);

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options (fonts will be embedded automatically if found)
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