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
        string inputPath = "input.gif";
        string outputPath = "output.lossy.gif";

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

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Apply gamma correction (example gamma value)
                gifImage.AdjustGamma(2.5f);

                // Prepare GIF save options for lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Set MaxDiff > 0 to enable lossy compression (recommended 80)
                    MaxDiff = 80
                };

                // Save the modified GIF with lossy compression
                gifImage.Save(outputPath, saveOptions);
            }

            Console.WriteLine($"Processed GIF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}