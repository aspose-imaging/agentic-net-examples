using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\input.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the EMF image
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Example processing: output image dimensions
            Console.WriteLine($"Loaded EMF image size: {emfImage.Width}x{emfImage.Height}");

            // Hardcoded output path (optional save)
            string outputPath = @"C:\temp\output.emf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the image (could be a processed version)
            emfImage.Save(outputPath);
        }
    }
}