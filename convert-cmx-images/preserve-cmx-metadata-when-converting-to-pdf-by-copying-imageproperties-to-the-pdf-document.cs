using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.cmx";
        string outputPath = "Output/sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = cmx.Width,
                    PageHeight = cmx.Height
                };

                cmx.Save(outputPath, pdfOptions);
            }
        }
    }
}