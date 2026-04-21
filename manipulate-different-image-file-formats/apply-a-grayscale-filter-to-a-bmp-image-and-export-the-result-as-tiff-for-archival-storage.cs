using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.bmp";
        string outputPath = "Output/sample.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image bmpImage = Image.Load(inputPath))
        {
            int width = bmpImage.Width;
            int height = bmpImage.Height;

            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image tiffImage = Image.Create(tiffOptions, width, height))
            {
                Graphics graphics = new Graphics(tiffImage);
                graphics.DrawImage(bmpImage, 0, 0);

                var tiffImg = (TiffImage)tiffImage;
                tiffImg.Grayscale();

                tiffImg.Save();
            }
        }
    }
}