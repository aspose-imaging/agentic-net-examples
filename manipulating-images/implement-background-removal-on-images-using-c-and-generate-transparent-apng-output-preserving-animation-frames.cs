using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        using (RasterImage source = (RasterImage)Image.Load(inputPath))
        {
            var maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                }
            };

            using (MaskingResult maskResult = new ImageMasking(source).Decompose(maskingOptions))
            {
                using (RasterImage mask = (RasterImage)maskResult[1].GetMask())
                {
                    if (mask.Width != source.Width || mask.Height != source.Height)
                    {
                        mask.Resize(source.Width, source.Height, ResizeType.NearestNeighbourResample);
                    }

                    ImageMasking.ApplyMask(source, mask, maskingOptions);
                }
            }

            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 100
            };

            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, source.Width, source.Height))
            {
                apng.RemoveAllFrames();
                apng.AddFrame(source);
                apng.Save();
            }
        }
    }
}