using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.cdr";
        string outputPath = "output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the CorelDRAW file, resize, and save as PNG
        using (CdrImage image = (CdrImage)Image.Load(inputPath))
        {
            // Resize to 1024x768 pixels using the default resampling method
            image.Resize(1024, 768);

            // Save the image as PNG
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}