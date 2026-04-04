using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main()
    {
        var inputs = new List<string>
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg"
        };

        var outputs = new List<string>
        {
            @"C:\Images\output1.png",
            @"C:\Images\output2.png"
        };

        for (int i = 0; i < inputs.Count; i++)
        {
            string inputPath = inputs[i];
            string outputPath = outputs[i];

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var maskingOptions = new GraphCutMaskingOptions
            {
                FeatheringRadius = 5,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                }
            };

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            int threshold = maskingOptions.FeatheringRadius;
            bool feathered = maskingOptions.FeatheringRadius > 0;
            Console.WriteLine($"{Path.GetFileName(inputPath)}, Threshold: {threshold}, Feathered: {feathered}");
        }
    }
}