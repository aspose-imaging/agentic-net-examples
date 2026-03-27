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
        string inputPath = "Animation.gif";
        string outputFolder = "Frames";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output folder exists
        Directory.CreateDirectory(outputFolder);

        // Load the animated GIF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access frames/pages
            GifImage gif = image as GifImage;
            if (gif == null)
            {
                Console.Error.WriteLine("The loaded image is not a GIF.");
                return;
            }

            // Iterate through each frame
            for (int i = 0; i < gif.PageCount; i++)
            {
                // Extract the frame as a RasterImage
                using (RasterImage frame = (RasterImage)gif.Pages[i])
                {
                    // Build output file path
                    string outputPath = Path.Combine(outputFolder, $"frame_{i}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as PNG
                    frame.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}