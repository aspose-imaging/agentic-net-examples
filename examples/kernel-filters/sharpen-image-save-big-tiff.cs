using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.tif";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            var bigTiffOptions = new BigTiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 8, 8, 8 },
                Photometric = TiffPhotometrics.Rgb,
                Compression = TiffCompressions.Lzw
            };

            raster.Save(outputPath, bigTiffOptions);
        }
    }
}