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
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the GIF animation
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Proceed only if the GIF has at least one frame
                if (gif.PageCount > 0)
                {
                    // Access the first frame as a RasterImage
                    var firstFrame = (RasterImage)gif.Pages[0];

                    // Apply Magic Wand selection on the first frame
                    // Example: start point (10,10) with default threshold
                    MagicWandTool
                        .Select(firstFrame, new MagicWandSettings(10, 10))
                        .Apply();
                }

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