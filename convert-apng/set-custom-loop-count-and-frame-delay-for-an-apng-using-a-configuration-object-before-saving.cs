using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input/source_image.png";
        string outputPath = "output/apng_result.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (can be any raster image)
            using (Image sourceImage = Image.Load(inputPath))
            {
                // Configure APNG options: custom loop count and frame delay
                ApngOptions apngOptions = new ApngOptions
                {
                    // Number of times the animation should loop (0 = infinite)
                    NumPlays = 4,
                    // Default frame duration in milliseconds
                    DefaultFrameTime = 150
                };

                // Save the image as APNG with the configured options
                sourceImage.Save(outputPath, apngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}