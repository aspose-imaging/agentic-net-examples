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
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Jpeg;
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                TiffFrame newFrame = new TiffFrame(frameOptions, 200, 200);
                tiffImage.AddFrame(newFrame);

                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Jpeg;
                saveOptions.Photometric = TiffPhotometrics.Rgb;
                saveOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                saveOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                tiffImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}