using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.pdf";

        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            PdfOptions pdfOptions = new PdfOptions();
            tiffImage.Save(outputPath, pdfOptions);
        }
    }
}