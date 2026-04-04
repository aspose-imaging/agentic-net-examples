using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine("Input", "sample.psd");
        string outputPath = Path.Combine("Output", "dimmed.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = image as RasterImage;
            if (raster != null)
            {
                if (!raster.IsCached) raster.CacheData();
                raster.AdjustBrightness(-15);
            }

            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}