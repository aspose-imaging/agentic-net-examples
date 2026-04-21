using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input_animation.webp";
        string outputPath = @"C:\Images\output_animation.gif";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the WebP image (may contain multiple frames)
            using (Image webpImage = Image.Load(inputPath))
            {
                // Prepare GIF options to preserve all frames
                var gifOptions = new GifOptions
                {
                    // Export full frames for each animation step
                    FullFrame = true
                };

                // Save as animated GIF; Aspose.Imaging retains animation frames automatically
                webpImage.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}