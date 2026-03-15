using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.tif";
        string outputPath = args.Length > 1 ? args[1] : "output.pdf";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = image as RasterImage;
            double hRes = raster != null ? raster.HorizontalResolution : 96;
            double vRes = raster != null ? raster.VerticalResolution : 96;

            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.ResolutionSettings = new ResolutionSetting(hRes, vRes);
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}