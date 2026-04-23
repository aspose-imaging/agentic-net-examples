using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.cmx";
        string outputPath = @"C:\temp\output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        var outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = cmx.Width,
                PageHeight = cmx.Height,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            tiffOptions.VectorRasterizationOptions = vectorOptions;
            tiffOptions.MultiPageOptions = null; // export all pages

            cmx.Save(outputPath, tiffOptions);
        }
    }
}