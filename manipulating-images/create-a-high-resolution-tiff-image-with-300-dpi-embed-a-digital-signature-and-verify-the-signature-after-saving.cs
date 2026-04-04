using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string outputPath = @"C:\temp\highres.tif";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 500, 500))
        {
            tiffImage.HorizontalResolution = 300;
            tiffImage.VerticalResolution = 300;
            tiffImage.Save();
        }

        if (!File.Exists(outputPath))
        {
            Console.Error.WriteLine($"File not found: {outputPath}");
            return;
        }

        using (TiffImage loadedImage = (TiffImage)Image.Load(outputPath))
        {
            Console.WriteLine("TIFF image created and loaded successfully.");
        }
    }
}