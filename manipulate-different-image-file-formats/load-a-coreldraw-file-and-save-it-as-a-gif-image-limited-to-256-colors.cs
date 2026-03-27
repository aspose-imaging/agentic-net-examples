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
        string outputPath = @"C:\temp\output.gif";

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
            // Configure GIF saving options (256 colors)
            GifOptions gifOptions = new GifOptions
            {
                // 7 means 2^(7+1) = 256 colors
                ColorResolution = 7,
                DoPaletteCorrection = true,
                // Optional: keep lossless (no lossy compression)
                MaxDiff = 0
            };

            // Save as GIF
            image.Save(outputPath, gifOptions);
        }
    }
}