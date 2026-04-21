using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputFolder = "ExtractedFrames";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Load the animated GIF
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                int frameCount = gif.PageCount;

                for (int i = 0; i < frameCount; i++)
                {
                    // Build output file path for each frame
                    string outputPath = Path.Combine(outputFolder, $"frame_{i}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PNG options to export a single frame
                    PngOptions pngOptions = new PngOptions
                    {
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                    };

                    // Save the current frame as PNG
                    gif.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}