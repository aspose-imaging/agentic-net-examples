using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.tif";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            double[,] edgeKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(edgeKernel));

            int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

            BigTiffOptions bigTiffOptions = new BigTiffOptions(TiffExpectedFormat.Default);
            bigTiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            bigTiffOptions.Compression = TiffCompressions.Deflate;
            bigTiffOptions.Photometric = TiffPhotometrics.Rgb;
            bigTiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            using (BigTiffImage bigTiff = (BigTiffImage)Image.Create(bigTiffOptions, raster.Width, raster.Height))
            {
                bigTiff.SaveArgb32Pixels(new Rectangle(0, 0, raster.Width, raster.Height), pixels);
                bigTiff.Save(outputPath, bigTiffOptions);
            }
        }
    }
}