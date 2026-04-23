using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine("Input", "sample.cmx");
        string outputPath = Path.Combine("Output", "sample.jpg");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            CmxImage cmxImage = (CmxImage)image;

            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.KeepMetadata = true;
                cmxImage.Save(outputPath, jpegOptions);
            }
        }
    }
}