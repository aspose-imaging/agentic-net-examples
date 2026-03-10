using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.tif";

        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White
            };

            BigTiffOptions tiffOptions = new BigTiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.VectorRasterizationOptions = rasterOptions;

            svgImage.Save(outputPath, tiffOptions);
        }
    }
}