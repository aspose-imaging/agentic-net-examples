using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (any supported format)
            using (Image sourceImage = Image.Load(inputPath))
            {
                // Prepare PNG save options (default options are sufficient for viewable PNG)
                PngOptions pngOptions = new PngOptions();

                // Save the image as PNG
                sourceImage.Save(outputPath, pngOptions);
            }

            // Validate that the saved PNG can be loaded (ensures it is viewable)
            using (PngImage savedPng = new PngImage(outputPath))
            {
                // Simple validation: check dimensions are greater than zero
                if (savedPng.Width > 0 && savedPng.Height > 0)
                {
                    Console.WriteLine("PNG file saved and validated successfully.");
                }
                else
                {
                    Console.Error.WriteLine("Saved PNG appears to be invalid (zero dimensions).");
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any runtime exception and report it without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}