using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        using (Image image = Image.Load(inputPath))
        {
            TiffImage tiffImage = (TiffImage)image;

            tiffImage.Filter(tiffImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            TiffFrame processedFrame = TiffFrame.CopyFrame(tiffImage.ActiveFrame);

            using (BigTiffImage bigTiff = new BigTiffImage(processedFrame))
            {
                BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default);
                bigTiff.Save(outputPath, options);
            }
        }
    }
}