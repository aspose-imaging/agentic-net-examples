using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.jpg";
        string outputPath = "Output/converted.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options
            PngOptions pngOptions = new PngOptions();

            // Simulate HTTP response stream with a file stream
            using (FileStream responseStream = new FileStream(outputPath, FileMode.Create))
            {
                // Save the image as PNG directly to the response stream
                image.Save(responseStream, pngOptions);
            }
        }
    }
}