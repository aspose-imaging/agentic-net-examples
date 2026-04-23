using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\input.png";
        string outputPath = "C:\\temp\\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Resize to 1024x768 pixels
            image.Resize(1024, 768);

            // Save directly to PDF format
            var pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}