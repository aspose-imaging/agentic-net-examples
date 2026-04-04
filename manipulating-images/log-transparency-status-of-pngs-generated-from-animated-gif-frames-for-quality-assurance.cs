using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define input GIF path and output directory
        string inputPath = "Input/animation.gif";
        string outputDirectory = "Output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the animated GIF
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            int frameCount = gif.PageCount;

            for (int i = 0; i < frameCount; i++)
            {
                // Prepare PNG output path for the current frame
                string pngPath = Path.Combine(outputDirectory, $"frame_{i}.png");

                // Ensure the directory for the PNG exists
                Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                // Set up PNG options to export only the current frame
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(pngPath, false),
                    MultiPageOptions = new MultiPageOptions(new IntRange(i, i))
                };

                // Save the current frame as PNG
                gif.Save(pngPath, pngOptions);

                // Load the saved PNG to check transparency (alpha channel)
                using (RasterImage png = (RasterImage)Image.Load(pngPath))
                {
                    bool hasAlpha = png.HasAlpha;
                    Console.WriteLine($"Frame {i}: PNG has alpha = {hasAlpha}");
                }
            }
        }
    }
}