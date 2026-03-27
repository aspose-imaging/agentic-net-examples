using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.emf";
        string outputPath = @"C:\Temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access EMF-specific functionality
            EmfImage emfImage = image as EmfImage;
            if (emfImage == null)
            {
                Console.Error.WriteLine("The loaded file is not an EMF image.");
                return;
            }

            // Convert and save as PDF
            PdfOptions pdfOptions = new PdfOptions();
            emfImage.Save(outputPath, pdfOptions);
        }
    }
}