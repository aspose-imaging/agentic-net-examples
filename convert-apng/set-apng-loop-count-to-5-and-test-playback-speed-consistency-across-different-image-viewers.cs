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
            string inputPath = "input_animation.webp";
            string outputPath = "output_animation.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (could be animated or single-frame)
            using (Image image = Image.Load(inputPath))
            {
                // Configure APNG options:
                // - Set loop count to 5
                // - Set default frame time to 100 ms to test playback speed consistency
                var apngOptions = new ApngOptions
                {
                    NumPlays = 5,
                    DefaultFrameTime = 100 // milliseconds per frame
                };

                // Save as APNG with the specified options
                image.Save(outputPath, apngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}