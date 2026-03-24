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
        string outputPath = @"C:\Images\output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Remove background if the image supports it
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground();
            }

            // Save as APNG (single-frame animation)
            image.Save(outputPath, new ApngOptions());
        }
    }
}