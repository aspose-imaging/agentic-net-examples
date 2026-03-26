using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "C:\\Temp\\input.dcm";
        string outputFolder = "C:\\Temp\\DicomPreviews";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputFolder);

        using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
        {
            int pageIndex = 0;
            foreach (DicomPage page in dicom.DicomPages)
            {
                string pngPath = Path.Combine(outputFolder, $"page_{pageIndex}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                page.Save(pngPath, new PngOptions());
                pageIndex++;
            }
        }
    }
}