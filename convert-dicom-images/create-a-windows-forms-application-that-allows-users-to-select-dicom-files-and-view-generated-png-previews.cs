using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        string inputPath = "input.dcm";
        string outputDirectory = "Previews";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            int pageIndex = 0;
            foreach (var dicomPage in dicomImage.DicomPages)
            {
                string pngPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                dicomPage.Save(pngPath, new PngOptions());
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pngPath) { UseShellExecute = true });
                pageIndex++;
            }
        }
    }
}