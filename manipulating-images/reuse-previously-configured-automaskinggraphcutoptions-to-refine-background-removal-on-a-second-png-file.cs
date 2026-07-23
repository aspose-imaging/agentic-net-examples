using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath1 = "input1.png";
        string outputPath1 = Path.Combine("output", "output1.png");
        string inputPath2 = "input2.png";
        string outputPath2 = Path.Combine("output", "output2.png");

        try
        {
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));

            using (RasterImage image1 = (RasterImage)Image.Load(inputPath1))
            {
                var options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath1, false)
                };
                image1.Save(outputPath1, options);
            }

            using (RasterImage image2 = (RasterImage)Image.Load(inputPath2))
            {
                var options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath2, false)
                };
                image2.Save(outputPath2, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to apply the same graph‑cut based AutoMaskingGraphCutOptions to multiple product photos to consistently remove the background from each PNG image.
 * 2. When an e‑commerce platform wants to batch‑process newly uploaded PNG files using previously tuned AutoMaskingGraphCutOptions to ensure uniform transparent backgrounds for catalog thumbnails.
 * 3. When a mobile app generates user‑edited stickers and must reuse the same background‑removal parameters on a second PNG to maintain visual consistency across stickers.
 * 4. When a digital marketing team automates the preparation of campaign assets and wants to apply the same AutoMaskingGraphCutOptions to a second PNG after the first image has been successfully processed.
 * 5. When a document‑generation service needs to embed PNG graphics with removed backgrounds and reuses the configured AutoMaskingGraphCutOptions to refine the mask on subsequent images without recalibrating the algorithm.
 */