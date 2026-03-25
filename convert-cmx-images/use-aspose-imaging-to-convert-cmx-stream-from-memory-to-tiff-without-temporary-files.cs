using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        byte[] cmxData = File.ReadAllBytes(inputPath);
        using (var memoryStream = new MemoryStream(cmxData))
        using (CmxImage cmxImage = (CmxImage)Image.Load(memoryStream))
        {
            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = cmxImage.Width,
                    PageHeight = cmxImage.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                tiffOptions.VectorRasterizationOptions = vectorOptions;

                cmxImage.Save(outputPath, tiffOptions);
            }
        }
    }
}