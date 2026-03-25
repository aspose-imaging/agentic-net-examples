using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\animation.apng";
        string outputPath = @"C:\Images\animation_converted.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG animation
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF options to reduce palette to 256 colors with best matching palette
            GifOptions gifOptions = new GifOptions
            {
                DoPaletteCorrection = true, // enables palette analysis for optimal 256‑color palette
                ColorResolution = 7         // maximum color resolution for GIF (2^8‑1 = 255)
            };

            // Save as GIF using the configured options
            image.Save(outputPath, gifOptions);
        }
    }
}