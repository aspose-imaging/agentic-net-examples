using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\vector_input.svg";
        string outputPath = @"C:\Images\output_apng.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image (vector or raster)
        using (Image image = Image.Load(inputPath))
        {
            // If the loaded image is a vector image, remove its background
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground();
            }

            // Save the result as an APNG file (single‑frame animation)
            var apngOptions = new ApngOptions();
            image.Save(outputPath, apngOptions);
        }
    }
}