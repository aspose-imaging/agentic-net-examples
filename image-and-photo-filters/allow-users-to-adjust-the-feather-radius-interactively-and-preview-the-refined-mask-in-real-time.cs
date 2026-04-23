using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            while (true)
            {
                Console.Write("Enter feather radius (or press Enter to exit): ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    break;

                if (!int.TryParse(line, out int radius))
                {
                    Console.WriteLine("Invalid number.");
                    continue;
                }

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    var options = new GraphCutMaskingOptions
                    {
                        FeatheringRadius = radius,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new StreamSource(new MemoryStream())
                        },
                        BackgroundReplacementColor = Color.Transparent
                    };

                    using (MaskingResult results = new ImageMasking(image).Decompose(options))
                    {
                        using (RasterImage foreground = (RasterImage)results[1].GetImage())
                        {
                            string outputPath = Path.Combine(outputDir, $"preview_{radius}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                            Console.WriteLine($"Saved preview to {outputPath}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}