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
        string inputPath = "input.svg";
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
        using (Image image = Image.Load(inputPath))
        {
            // Remove background if the image is a vector type
            if (image is VectorImage vectorImg)
            {
                vectorImg.RemoveBackground();
            }

            // Save the result as an APNG preserving transparency
            image.Save(outputPath, new ApngOptions());
        }
    }
}