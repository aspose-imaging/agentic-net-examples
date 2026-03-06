using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        using (BigTiffImage bigTiff = (BigTiffImage)Image.Load(inputPath))
        {
            bigTiff.Filter(bigTiff.Bounds, new GaussWienerFilterOptions(5, 4.0));

            BigTiffOptions saveOptions = new BigTiffOptions(TiffExpectedFormat.Default);
            saveOptions.Compression = TiffCompressions.AdobeDeflate;
            saveOptions.Photometric = TiffPhotometrics.Rgb;

            bigTiff.Save(outputPath, saveOptions);
        }
    }
}