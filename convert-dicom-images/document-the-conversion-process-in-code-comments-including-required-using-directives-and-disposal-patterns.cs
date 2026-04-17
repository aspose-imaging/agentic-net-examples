using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths (relative to the application directory)
        string inputPath = Path.Combine("Input", "sample.jpg");
        string outputPath = Path.Combine("Output", "sample.tif");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image and automatically dispose it after use
        using (Image image = Image.Load(inputPath))
        {
            // Convert and save the image to TIFF format using default options
            image.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
        }
    }
}