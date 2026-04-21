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
            string inputPath = @"C:\Images\input.gif";
            string outputPath = @"C:\Images\output.lossy.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF options for lossy compression
                GifOptions options = new GifOptions
                {
                    MaxDiff = 80,               // Recommended value for effective lossy compression
                    DoPaletteCorrection = true,
                    Interlaced = false
                };

                // Save the image using the lossy options
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}