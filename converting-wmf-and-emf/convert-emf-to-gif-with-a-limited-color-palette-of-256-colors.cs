using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Configure GIF save options with a 256‑color palette
            GifOptions gifOptions = new GifOptions
            {
                // Enable palette correction to build an optimal 256‑color palette
                DoPaletteCorrection = true,
                // ColorResolution = 7 means 8 bits per primary color (2^8 = 256 colors)
                ColorResolution = 7
            };

            // Save the image as GIF using the configured options
            emfImage.Save(outputPath, gifOptions);
        }
    }
}