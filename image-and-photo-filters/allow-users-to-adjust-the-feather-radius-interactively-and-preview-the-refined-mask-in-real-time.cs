using System;
using System.IO;
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
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            while (true)
            {
                Console.Write("Enter feather radius (or 'q' to quit): ");
                string line = Console.ReadLine();
                if (line == null) break;
                if (line.Trim().ToLower() == "q") break;

                if (!int.TryParse(line, out int radius) || radius < 0)
                {
                    Console.WriteLine("Invalid radius. Please enter a non‑negative integer.");
                    continue;
                }

                string outputPath = $"output_feather_{radius}.png";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    var options = new AutoMaskingGraphCutOptions
                    {
                        CalculateDefaultStrokes = true,
                        FeatheringRadius = radius,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new StreamSource(new MemoryStream())
                        },
                        BackgroundReplacementColor = Aspose.Imaging.Color.Transparent
                    };

                    MaskingResult results = new ImageMasking(image).Decompose(options);
                    using (Aspose.Imaging.RasterImage resultImage = (Aspose.Imaging.RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }

                Console.WriteLine($"Saved masked image with feather radius {radius} to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}