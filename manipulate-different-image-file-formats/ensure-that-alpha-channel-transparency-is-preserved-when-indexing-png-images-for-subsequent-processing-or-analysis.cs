using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main(string[] args)
    {
        // Paths to the source PNG (with alpha) and the indexed PNG output
        string inputPath = "input.png";
        string outputPath = "output_indexed.png";

        // Load the source image. It may contain an alpha channel.
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG options to use indexed color.
            // The palette generated from the source image includes transparent entries,
            // thereby preserving the original alpha information.
            PngOptions options = new PngOptions
            {
                ColorType = PngColorType.IndexedColor,
                CompressionLevel = 9,
                Palette = ColorPaletteHelper.GetCloseImagePalette((RasterImage)image, 256, PaletteMiningMethod.Histogram)
            };

            // Save the image as an indexed PNG while keeping transparency.
            image.Save(outputPath, options);
        }
    }
}