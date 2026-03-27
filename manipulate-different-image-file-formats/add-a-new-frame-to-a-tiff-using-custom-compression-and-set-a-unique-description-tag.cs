using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            frameOptions.Photometric = TiffPhotometrics.Rgb;
            frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            frameOptions.Compression = TiffCompressions.Lzw;

            int width = 200;
            int height = 200;
            TiffFrame newFrame = new TiffFrame(frameOptions, width, height);

            Color[] greenPixels = Enumerable.Repeat(Color.Green, width * height).ToArray();
            newFrame.SavePixels(newFrame.Bounds, greenPixels);

            tiffImage.AddFrame(newFrame);
            tiffImage.Save(outputPath);
        }
    }
}