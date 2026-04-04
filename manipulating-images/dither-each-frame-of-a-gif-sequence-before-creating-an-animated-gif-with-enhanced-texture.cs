using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output_dithered.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source GIF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF‑specific members
            GifImage gif = (GifImage)image;

            // Apply Floyd‑Steinberg dithering with a 4‑bit palette (16 colors)
            // This operation is performed on every frame of the animated GIF.
            gif.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

            // Save the dithered animated GIF
            gif.Save(outputPath);
        }
    }
}