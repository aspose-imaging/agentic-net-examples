using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CorelDRAW (CDR) file
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF save options (256‑color palette)
            var gifOptions = new GifOptions
            {
                // Number of bits per primary color minus 1 (7 => 8 bits)
                ColorResolution = 7,
                // Analyze source colors to build the best matching palette
                DoPaletteCorrection = true,
                // Optional: interlaced GIF
                Interlaced = false
            };

            // Save as GIF using the configured options
            image.Save(outputPath, gifOptions);
        }
    }
}