using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Animation.gif";
        string outputPath = "ProcessedAnimation.gif";

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

            // Load the GIF animation
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Access the first frame (page) of the GIF
                RasterImage firstFrame = (RasterImage)gif.Pages[0];

                // Apply Magic Wand selection on the first frame
                // Example: select area around pixel (120,100) with default threshold
                MagicWandTool
                    .Select(firstFrame, new MagicWandSettings(120, 100))
                    .Apply();

                // Save the modified GIF animation
                gif.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}