using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Apply an emboss convolution filter
            image.Filter(image.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Select a color area using Magic Wand and apply the mask
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                .Apply();

            // Save the processed image with alpha channel support
            image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }
    }
}