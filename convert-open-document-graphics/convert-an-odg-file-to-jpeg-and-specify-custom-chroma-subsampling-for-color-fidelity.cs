using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        string inputPath = Path.Combine(inputDirectory, "sample.odg");
        string outputPath = Path.Combine(outputDirectory, "sample.jpg");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.HorizontalSampling = new byte[] { 2, 2, 2 };
                jpegOptions.VerticalSampling = new byte[] { 2, 2, 2 };
                jpegOptions.Quality = 90;
                jpegOptions.ColorType = JpegCompressionColorMode.YCbCr;

                image.Save(outputPath, jpegOptions);
            }
        }
    }
}