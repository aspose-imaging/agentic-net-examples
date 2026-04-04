using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
        string ditheredPath = @"C:\temp\output_dithered.gif";
        string lossyPath = @"C:\temp\output_lossy.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(ditheredPath));
        Directory.CreateDirectory(Path.GetDirectoryName(lossyPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific methods
            GifImage gifImage = (GifImage)image;

            // Apply dithering (using Floyd‑Steinberg with 8‑bit palette)
            gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

            // Save the dithered GIF (lossless)
            gifImage.Save(ditheredPath, new GifOptions());

            // Prepare options for lossy compression
            GifOptions lossyOptions = new GifOptions
            {
                MaxDiff = 80 // Recommended value for optimal lossy compression
            };

            // Save the same dithered image using lossy compression
            gifImage.Save(lossyPath, lossyOptions);
        }
    }
}