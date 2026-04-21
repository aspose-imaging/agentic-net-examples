using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG export options for lossless archival storage
            var pngOptions = new PngOptions
            {
                // Use the default (lossless) compression level
                PngCompressionLevel = PngOptions.DefaultCompressionLevel
            };

            // Save the image as PNG using the specified options
            image.Save(outputPath, pngOptions);
        }
    }
}