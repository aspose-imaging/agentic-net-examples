using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.cdr";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Check that the loaded image is a vector image
            if (image is VectorImage vectorImage)
            {
                try
                {
                    // Attempt to remove the background
                    vectorImage.RemoveBackground();
                }
                catch (Exception ex)
                {
                    // Handle cases where background removal fails (e.g., no recognizable vector shapes)
                    Console.Error.WriteLine($"RemoveBackground failed: {ex.Message}");
                    return;
                }

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                vectorImage.Save(outputPath, pngOptions);
            }
            else
            {
                Console.Error.WriteLine("The provided file is not a vector image.");
                return;
            }
        }
    }
}