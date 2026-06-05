using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.png";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the CDR file as a generic Image, then cast to VectorImage
            using (Image image = Image.Load(inputPath))
            {
                // Cast to VectorImage to access background removal functionality
                var vectorImage = (VectorImage)image;

                // Remove the background using default settings
                vectorImage.RemoveBackground();

                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image
                vectorImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}