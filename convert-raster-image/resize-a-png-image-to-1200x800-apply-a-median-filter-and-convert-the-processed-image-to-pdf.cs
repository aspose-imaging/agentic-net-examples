using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.png";
        string outputPath = "Output/processed.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            if (!raster.IsCached)
                raster.CacheData();

            raster.Resize(1200, 800);

            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}