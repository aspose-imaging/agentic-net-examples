using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                tiffOptions.Compression = TiffCompressions.Lzw;
                tiffOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, tiffOptions);
            }
        }
    }
}