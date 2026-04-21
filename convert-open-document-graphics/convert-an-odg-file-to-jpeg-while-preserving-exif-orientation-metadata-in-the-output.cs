using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.odg";
        string outputPath = "Output\\sample.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.FileFormats.OpenDocument.OdgImage odgImage = (Aspose.Imaging.FileFormats.OpenDocument.OdgImage)Image.Load(inputPath))
        {
            using (JpegOptions jpegOptions = new JpegOptions
            {
                KeepMetadata = true
            })
            {
                odgImage.Save(outputPath, jpegOptions);
            }
        }
    }
}