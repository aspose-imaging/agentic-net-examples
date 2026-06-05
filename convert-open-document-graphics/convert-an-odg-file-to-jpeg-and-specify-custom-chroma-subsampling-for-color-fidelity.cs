using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    ColorType = JpegCompressionColorMode.YCbCr,
                    HorizontalSampling = new byte[] { 2, 1, 1 },
                    VerticalSampling = new byte[] { 2, 1, 1 }
                };

                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}