using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.jpg");

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
                jpegOptions.KeepMetadata = true;

                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, jpegOptions);
            }
        }
    }
}