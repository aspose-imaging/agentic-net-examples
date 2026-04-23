using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputPath = "output/output.gif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional call as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image (may contain animation frames)
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF options: infinite loop
                GifOptions gifOptions = new GifOptions
                {
                    LoopsCount = 0 // 0 means infinite looping
                };

                // Save as animated GIF preserving frames
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}