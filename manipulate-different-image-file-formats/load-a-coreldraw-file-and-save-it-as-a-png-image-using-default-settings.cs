using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CorelDRAW (CDR) file
        using (Image image = Image.Load(inputPath))
        {
            // Use default PNG options
            PngOptions pngOptions = new PngOptions();

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}