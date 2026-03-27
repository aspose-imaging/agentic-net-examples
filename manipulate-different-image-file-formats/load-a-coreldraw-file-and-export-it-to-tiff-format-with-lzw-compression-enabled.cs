using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "C:\\Images\\sample.cdr";
        string outputPath = "C:\\Images\\output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image cdrImage = Image.Load(inputPath))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions();
                cdrImage.Save(ms, pngOptions);
                ms.Position = 0;

                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                    tiffOptions.Compression = TiffCompressions.Lzw;
                    tiffOptions.Photometric = TiffPhotometrics.Rgb;
                    tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                    raster.Save(outputPath, tiffOptions);
                }
            }
        }
    }
}