using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.cdr";
        string outputPath = @"c:\temp\sample.png";

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
            // Create default PNG save options
            PngOptions pngOptions = new PngOptions();

            // Save the image as PNG using the default options
            image.Save(outputPath, pngOptions);
        }
    }
}