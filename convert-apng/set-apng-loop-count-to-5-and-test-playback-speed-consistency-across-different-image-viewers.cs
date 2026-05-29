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
            string inputPath = "Animation1.webp";
            string outputPath = "output/Animation1_5loops.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (could be animated)
            using (Image image = Image.Load(inputPath))
            {
                // Configure APNG options: set loop count to 5
                // Optionally, set a fixed frame duration to test playback speed consistency
                var apngOptions = new ApngOptions
                {
                    NumPlays = 5,
                    // Uncomment the line below to enforce a uniform frame time (e.g., 100 ms)
                    // DefaultFrameTime = 100
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