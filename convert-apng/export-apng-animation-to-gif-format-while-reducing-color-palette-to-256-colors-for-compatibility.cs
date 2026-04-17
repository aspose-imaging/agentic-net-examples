using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG animation
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF export options
            var gifOptions = new GifOptions
            {
                // Enable palette analysis to build an optimal 256‑color palette
                DoPaletteCorrection = true
                // Optional: set color resolution (7 => 8 bits per channel, max 256 colors)
                // ColorResolution = 7
            };

            // Save as GIF with reduced palette
            image.Save(outputPath, gifOptions);
        }
    }
}