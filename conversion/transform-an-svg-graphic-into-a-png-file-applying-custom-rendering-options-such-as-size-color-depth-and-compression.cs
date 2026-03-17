using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        int targetWidth = 800;
        int targetHeight = 600;
        int bitDepth = 8;
        var compressionLevel = PngCompressionLevel.ZipLevel6;

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = new Aspose.Imaging.SizeF(targetWidth, targetHeight);
            rasterOptions.BackgroundColor = Aspose.Imaging.Color.White;

            PngOptions pngOptions = new PngOptions();
            pngOptions.BitDepth = (byte)bitDepth;
            pngOptions.ColorType = PngColorType.TruecolorWithAlpha;
            pngOptions.PngCompressionLevel = compressionLevel;
            pngOptions.VectorRasterizationOptions = rasterOptions;

            svgImage.Save(outputPath, pngOptions);
        }
    }
}