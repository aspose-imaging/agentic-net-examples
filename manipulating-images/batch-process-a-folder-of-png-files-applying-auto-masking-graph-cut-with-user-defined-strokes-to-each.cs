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
            string inputDir = "InputImages";
            string outputDir = "OutputImages";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] files = Directory.GetFiles(inputDir, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_masked.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    AutoMaskingArgs userStrokes = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][]
                        {
                            new Point[] { new Point(10, 10), new Point(20, 10) },
                            new Point[] { new Point(30, 30) }
                        }
                    };

                    string tempExportPath = Path.GetTempFileName();

                    AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                    {
                        CalculateDefaultStrokes = false,
                        FeatheringRadius = 3,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        Args = userStrokes,
                        BackgroundReplacementColor = Color.Transparent,
                        ExportOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource(tempExportPath, false)
                        }
                    };

                    MaskingResult result = new ImageMasking(image).Decompose(options);

                    using (RasterImage resultImage = (RasterImage)result[1].GetImage())
                    {
                        resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }

                    if (File.Exists(tempExportPath))
                    {
                        File.Delete(tempExportPath);
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