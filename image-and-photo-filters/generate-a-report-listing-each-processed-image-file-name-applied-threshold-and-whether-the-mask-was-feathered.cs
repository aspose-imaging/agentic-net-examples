using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] files = Directory.GetFiles(inputDirectory);
            var reportLines = new List<string>();
            reportLines.Add("FileName,Threshold,Feathered");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                int threshold = 150;
                bool feathered = true;

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (feathered)
                    {
                        MagicWandTool.Select(image, new MagicWandSettings(10, 10) { Threshold = threshold })
                            .GetFeathered(new FeatheringSettings() { Size = 3 })
                            .Apply();
                    }
                    else
                    {
                        MagicWandTool.Select(image, new MagicWandSettings(10, 10) { Threshold = threshold })
                            .Apply();
                    }

                    image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                reportLines.Add($"{fileName},{threshold},{feathered}");
            }

            string reportPath = Path.Combine(outputDirectory, "report.csv");
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));
            File.WriteAllLines(reportPath, reportLines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}