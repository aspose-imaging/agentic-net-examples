using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
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

                using (TiffFrame newFrame = new TiffFrame(frameOptions, 200, 200))
                {
                    using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                        new Point(0, 0),
                        new Point(newFrame.Width, newFrame.Height),
                        Color.Blue,
                        Color.Yellow))
                    {
                        Graphics graphics = new Graphics(newFrame);
                        graphics.FillRectangle(gradientBrush, newFrame.Bounds);
                    }

                    tiffImage.AddFrame(newFrame);
                }

                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}