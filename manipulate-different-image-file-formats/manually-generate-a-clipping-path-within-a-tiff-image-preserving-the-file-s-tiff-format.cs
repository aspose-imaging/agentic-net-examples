using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "ImageWithClippingPath.tif";

        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 800, 600))
        {
            tiffImage.Save(outputPath);
        }
    }
}