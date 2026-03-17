using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        using (Image image = Image.Load(inputPath))
        {
            BigTiffImage bigTiff = (BigTiffImage)image;

            bigTiff.Filter(bigTiff.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            var saveOptions = new BigTiffOptions(TiffExpectedFormat.Default);
            saveOptions.Compression = TiffCompressions.AdobeDeflate;
            saveOptions.Photometric = TiffPhotometrics.Rgb;
            saveOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            bigTiff.Save(outputPath, saveOptions);
        }
    }
}