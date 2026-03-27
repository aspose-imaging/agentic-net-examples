using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = "input.dcm";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                dicomImage.Save(outputPath, pdfOptions);
            }
        }
    }
}