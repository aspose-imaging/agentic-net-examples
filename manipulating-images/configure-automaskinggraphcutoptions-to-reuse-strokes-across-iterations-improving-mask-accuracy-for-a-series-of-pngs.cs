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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath1 = Path.Combine(outputDirectory, fileName + "_mask1.png");
                string outputPath2 = Path.Combine(outputDirectory, fileName + "_mask2.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    string tempPath = Path.GetTempFileName();

                    var options = new AutoMaskingGraphCutOptions
                    {
                        CalculateDefaultStrokes = true,
                        FeatheringRadius = 3,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource(tempPath, false)
                        },
                        BackgroundReplacementColor = Color.Transparent
                    };

                    MaskingResult results = new ImageMasking(image).Decompose(options);
                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputPath1, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }

                    options.CalculateDefaultStrokes = false;
                    results = new ImageMasking(image).Decompose(options);
                    using (RasterImage resultImage2 = (RasterImage)results[1].GetImage())
                    {
                        resultImage2.Save(outputPath2, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }

                    if (File.Exists(tempPath))
                    {
                        File.Delete(tempPath);
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