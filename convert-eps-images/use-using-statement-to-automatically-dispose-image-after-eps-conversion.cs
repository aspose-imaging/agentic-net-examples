using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\Result\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image, convert and save as PNG
        // The using statement guarantees disposal of the image object
        using (Image image = Image.Load(inputPath))
        {
            // Set PNG-specific options if needed
            var pngOptions = new PngOptions();

            // Save the image to the output path using the PNG options
            image.Save(outputPath, pngOptions);
        }
    }
}