using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input GIF and output folder
        string inputPath = "Animation.gif";
        string outputFolder = "Frames";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output folder exists
            Directory.CreateDirectory(outputFolder);

            // Load the animated GIF
            using (GifImage gifImage = (GifImage)Image.Load(inputPath))
            {
                int frameCount = gifImage.PageCount;

                // Iterate through each frame
                for (int i = 0; i < frameCount; i++)
                {
                    // Build output file path (e.g., Frames/frame_000.png)
                    string outputPath = Path.Combine(outputFolder, $"frame_{i:D3}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Get the frame as a RasterImage
                    using (RasterImage frame = (RasterImage)gifImage.Pages[i])
                    {
                        // Save the frame as PNG
                        var pngOptions = new PngOptions();
                        frame.Save(outputPath, pngOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}