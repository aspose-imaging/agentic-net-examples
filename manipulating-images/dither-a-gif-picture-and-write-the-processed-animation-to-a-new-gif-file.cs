using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output_dithered.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF‑specific functionality
            GifImage gifImage = (GifImage)image;

            // Apply Floyd‑Steinberg dithering using an 8‑bit palette (full color)
            gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

            // Save the processed animation as a new GIF file
            gifImage.Save(outputPath);
        }
    }
}