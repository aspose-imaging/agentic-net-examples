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
                // Save as APNG with 5 loop cycles
                var apngOptions = new ApngOptions
                {
                    NumPlays = 5,
                    // Preserve original frame timing if possible
                    // If the source has no frame timing, a default can be set here
                    // DefaultFrameTime = 100 // uncomment to set a fixed frame duration (ms)
                };

                image.Save(outputPath, apngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}