using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input.svg> <output.tif> [compression]");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        TiffCompressions compression = TiffCompressions.None;
        if (args.Length >= 3 && Enum.TryParse<TiffCompressions>(args[2], true, out var parsedCompression))
        {
            compression = parsedCompression;
        }

        using (Image image = Image.Load(inputPath))
        {
            VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White
            };

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                VectorRasterizationOptions = rasterOptions,
                Compression = compression,
                Photometric = TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 },
                PlanarConfiguration = TiffPlanarConfigs.Contiguous
            };

            image.Save(outputPath, tiffOptions);
        }
    }
}