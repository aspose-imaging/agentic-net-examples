using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = 3000,
                PageHeight = 3000,
                BackgroundColor = Color.White
            };

            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                VectorRasterizationOptions = rasterOptions
            };

            image.Save(outputPath, tiffOptions);
        }
    }
}