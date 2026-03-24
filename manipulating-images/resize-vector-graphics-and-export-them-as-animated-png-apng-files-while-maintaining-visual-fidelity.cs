using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.svg";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (VectorImage vectorImage = (VectorImage)Image.Load(inputPath))
        {
            // Define target dimensions (maintaining aspect ratio is up to the caller)
            int targetWidth = 800;
            int targetHeight = 600;

            // Resize the vector image – rasterization occurs during save
            vectorImage.Resize(targetWidth, targetHeight);

            // Prepare APNG save options (default frame time, infinite loops)
            var apngOptions = new ApngOptions();

            // Save the resized image as an animated PNG (single‑frame animation)
            vectorImage.Save(outputPath, apngOptions);
        }
    }
}