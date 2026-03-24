using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\vector_input.svg";
        string outputPath = @"C:\Images\Processed\vector_output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image (vector formats are supported by the unified Load method)
        using (Image image = Image.Load(inputPath))
        {
            // Proceed only if the loaded image is a vector image
            if (image is VectorImage vectorImage)
            {
                // Remove the background using the built‑in method
                vectorImage.RemoveBackground();

                // Save the processed image back to disk
                vectorImage.Save(outputPath);
            }
            else
            {
                Console.Error.WriteLine("The provided file is not a supported vector image.");
            }
        }
    }
}