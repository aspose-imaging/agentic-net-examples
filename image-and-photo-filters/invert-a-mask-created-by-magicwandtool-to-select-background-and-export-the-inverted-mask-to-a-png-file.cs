using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create mask based on a reference pixel and invert it to select the background
                ImageBitMask invertedMask = MagicWandTool
                    .Select(image, new MagicWandSettings(120, 100))
                    .Invert();

                // Create a blank canvas bound to the output file
                using (Image canvas = Image.Create(
                    new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath)
                    },
                    image.Width,
                    image.Height))
                {
                    RasterImage rasterCanvas = (RasterImage)canvas;
                    // Apply the inverted mask to the canvas
                    invertedMask.ApplyTo(rasterCanvas);
                    // Save the bound canvas
                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}