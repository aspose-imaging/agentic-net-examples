using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the entire logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        // Handle BMP-specific exceptions
        catch (Aspose.Imaging.CoreExceptions.ImageFormats.BmpImageException ex)
        {
            Console.Error.WriteLine($"BMP image error: {ex.Message}");
        }
        // Handle any other exceptions
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}