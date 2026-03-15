using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input.tif> <output.tif>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (TiffImage image = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
        {
            var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
            saveOptions.Compression = TiffCompressions.Lzw;
            saveOptions.Predictor = TiffPredictor.Horizontal;
            saveOptions.Photometric = TiffPhotometrics.Rgb;
            saveOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            image.Save(outputPath, saveOptions);
        }
    }
}