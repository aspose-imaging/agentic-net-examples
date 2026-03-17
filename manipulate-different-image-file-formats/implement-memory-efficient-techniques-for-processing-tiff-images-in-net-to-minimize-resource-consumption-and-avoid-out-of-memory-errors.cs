using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        LoadOptions loadOptions = new LoadOptions { BufferSizeHint = 10 };

        using (TiffImage sourceTiff = (TiffImage)Image.Load(inputPath, loadOptions))
        {
            sourceTiff.UseRawData = true;

            TiffOptions exportOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                Photometric = TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 },
                Compression = TiffCompressions.Lzw
            };

            sourceTiff.PageExportingAction = (int pageIndex, Image page) =>
            {
                RasterImage raster = (RasterImage)page;
                if (!raster.IsCached)
                    raster.CacheData();

                int newWidth = raster.Width / 2;
                int newHeight = raster.Height / 2;
                raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
            };

            sourceTiff.Save(outputPath, exportOptions);
        }
    }
}