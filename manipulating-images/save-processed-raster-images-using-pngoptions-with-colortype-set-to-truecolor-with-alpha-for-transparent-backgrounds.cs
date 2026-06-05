using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try/catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with Truecolor with Alpha (transparent background support)
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    BitDepth = 8 // typical 8 bits per channel
                };

                // Save the image as PNG using the configured options
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any error message without crashing the application
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}