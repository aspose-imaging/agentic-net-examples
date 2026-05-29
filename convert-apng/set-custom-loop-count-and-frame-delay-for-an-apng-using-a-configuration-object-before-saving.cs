using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\source.png";
            string outputPath = @"C:\Images\output_apng.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure APNG options: custom loop count and frame delay
                var apngOptions = new ApngOptions
                {
                    // Number of times the animation should loop (0 = infinite)
                    NumPlays = 3,
                    // Default frame duration in milliseconds
                    DefaultFrameTime = 200
                };

                // Save as APNG with the configured options
                image.Save(outputPath, apngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}