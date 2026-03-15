using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        using (BigTiffImage bigTiff = (BigTiffImage)Image.Load(inputPath))
        {
            var deconvOptions = new DeconvolutionFilterOptions(ConvolutionFilter.GetGaussian(5, 4.0));
            bigTiff.Filter(bigTiff.Bounds, deconvOptions);

            var saveOptions = new BigTiffOptions(TiffExpectedFormat.Default);
            saveOptions.Compression = TiffCompressions.AdobeDeflate;
            saveOptions.Photometric = TiffPhotometrics.Rgb;
            saveOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            bigTiff.Save(outputPath, saveOptions);
        }
    }
}