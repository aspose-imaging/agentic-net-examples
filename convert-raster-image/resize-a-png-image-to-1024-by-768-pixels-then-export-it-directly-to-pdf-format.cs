using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image, resize it, and save directly as PDF
        using (Image image = Image.Load(inputPath))
        {
            // Resize to 1024x768 pixels
            image.Resize(1024, 768);

            // Save as PDF using default PDF options
            image.Save(outputPath, new PdfOptions());
        }
    }
}