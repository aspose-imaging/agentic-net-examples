using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.png";
        string outputPdfPath = "Output/filtered.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

            using (PdfOptions pdfOptions = new PdfOptions())
            {
                raster.Save(outputPdfPath, pdfOptions);
            }
        }
    }
}