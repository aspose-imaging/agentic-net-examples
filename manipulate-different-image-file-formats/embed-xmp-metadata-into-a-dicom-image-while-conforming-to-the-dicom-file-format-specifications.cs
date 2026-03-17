using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.dcm";

        using (Image rasterImage = Image.Load(inputPath))
        {
            var dicomOptions = new DicomOptions();
            rasterImage.Save(outputPath, dicomOptions);
        }

        Console.WriteLine("DICOM image saved.");
    }
}