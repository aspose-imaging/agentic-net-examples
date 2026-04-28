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
            string inputPath = "input/animation.apng";
            string outputPath = "output/animation.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG animation
            using (Image apngImage = Image.Load(inputPath))
            {
                // Configure GIF options to reduce palette to 256 colors
                GifOptions gifOptions = new GifOptions
                {
                    // Enable palette correction to build an optimal 256‑color palette
                    DoPaletteCorrection = true,
                    // Set color resolution (bits per color channel minus 1). 7 => 8 bits => 256 colors
                    ColorResolution = 7
                };

                // Save as GIF using the configured options
                apngImage.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}