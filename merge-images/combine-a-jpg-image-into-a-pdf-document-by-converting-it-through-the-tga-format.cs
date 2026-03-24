using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputJpgPath = "input.jpg";
        string intermediateTgaPath = "temp.tga";
        string outputPdfPath = "output.pdf";

        // Verify input JPG exists
        if (!File.Exists(inputJpgPath))
        {
            Console.Error.WriteLine($"File not found: {inputJpgPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(intermediateTgaPath) ?? string.Empty);
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath) ?? string.Empty);

        // Convert JPG to TGA
        using (RasterImage jpegImage = (JpegImage)Image.Load(inputJpgPath))
        {
            jpegImage.Save(intermediateTgaPath, new TgaOptions());
        }

        // Verify intermediate TGA exists (optional safety)
        if (!File.Exists(intermediateTgaPath))
        {
            Console.Error.WriteLine($"File not found: {intermediateTgaPath}");
            return;
        }

        // Convert TGA to PDF
        using (RasterImage tgaImage = (TgaImage)Image.Load(intermediateTgaPath))
        {
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                tgaImage.Save(outputPdfPath, pdfOptions);
            }
        }
    }
}