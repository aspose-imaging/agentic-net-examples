using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input images of different resolutions (must exist in the working directory)
            string[] inputPaths = {
                "image_640x480.png",
                "image_1280x720.png",
                "image_1920x1080.png"
            };

            // Output directory
            string outputDir = "Output";

            // Ensure the output directory exists (once)
            Directory.CreateDirectory(outputDir);

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputFileName = $"mask_{Path.GetFileNameWithoutExtension(inputPath)}.png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image and apply MagicWand mask
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Use the center point as the reference for the mask
                    int centerX = image.Width / 2;
                    int centerY = image.Height / 2;

                    Stopwatch sw = Stopwatch.StartNew();

                    MagicWandTool
                        .Select(image, new MagicWandSettings(centerX, centerY))
                        .Apply();

                    sw.Stop();

                    // Save the masked image as PNG with alpha channel
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    };
                    image.Save(outputPath, pngOptions);

                    Console.WriteLine($"{Path.GetFileName(inputPath)} processed in {sw.ElapsedMilliseconds} ms");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}