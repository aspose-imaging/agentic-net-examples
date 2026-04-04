using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            TiffImage tiff = (TiffImage)image;

            tiff.AdjustGamma(2.5f);

            tiff.Filter(tiff.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));

            PdfOptions pdfOptions = new PdfOptions();
            tiff.Save(outputPath, pdfOptions);
        }
    }
}