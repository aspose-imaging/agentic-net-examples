using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multi‑page TIFF image
        using (Image tiffImage = Image.Load(inputPath))
        {
            // Prepare GIF save options with lossy compression
            GifOptions gifOptions = new GifOptions
            {
                // Recommended lossy level; adjust as needed
                MaxDiff = 80,
                // Optional: improve palette quality
                DoPaletteCorrection = true,
                // Interlacing is not required for animation integrity here
                Interlaced = false
            };

            // Save the TIFF frames as an animated GIF using the options above
            tiffImage.Save(outputPath, gifOptions);
        }
    }
}