using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var odgImage = (OdgImage)image;

            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.KeepMetadata = true;
                jpegOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = odgImage.Width,
                    PageHeight = odgImage.Height
                };

                image.Save(outputPath, jpegOptions);
            }
        }
    }
}