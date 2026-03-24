using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Process only vector images
            if (image is VectorImage vectorImage)
            {
                // Remove the background while preserving vector data
                vectorImage.RemoveBackground();

                // Save the resulting image to the output path
                vectorImage.Save(outputPath);
            }
            else
            {
                Console.Error.WriteLine("The provided file is not a supported vector image.");
            }
        }
    }
}