using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
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
            frameOptions.Compression = TiffCompressions.Jpeg;
            frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            frameOptions.Photometric = TiffPhotometrics.Ycbcr;

            TiffFrame newFrame = new TiffFrame(frameOptions, 200, 200);
            tiffImage.AddFrame(newFrame);
            tiffImage.Save(outputPath);
        }
    }
}