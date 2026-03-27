using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image, process it, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Create PNG save options (default settings)
            PngOptions pngOptions = new PngOptions();

            // Save the image to the output path
            image.Save(outputPath, pngOptions);
        } // Image is disposed here, freeing unmanaged resources
    }
}