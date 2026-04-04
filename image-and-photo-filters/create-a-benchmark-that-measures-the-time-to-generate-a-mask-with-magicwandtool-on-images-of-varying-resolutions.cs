using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths for different resolutions
        string[] inputPaths = { "input_small.png", "input_medium.png", "input_large.png" };
        string[] outputPaths = { "output_small.png", "output_medium.png", "output_large.png" };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Start timing
            Stopwatch sw = Stopwatch.StartNew();

            // Load image, apply MagicWand mask, and save result
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Use the image centre as the seed point for the magic wand
                int seedX = image.Width / 2;
                int seedY = image.Height / 2;

                // Create mask and apply it to the image
                MagicWandTool.Select(image, new MagicWandSettings(seedX, seedY)).Apply();

                // Save the masked image as PNG with alpha channel
                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }

            sw.Stop();
            Console.WriteLine($"Processed {inputPath} in {sw.ElapsedMilliseconds} ms");
        }
    }
}