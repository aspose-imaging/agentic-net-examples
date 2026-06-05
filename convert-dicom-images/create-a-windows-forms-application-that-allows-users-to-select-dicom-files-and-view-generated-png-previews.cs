using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (var page in dicomImage.DicomPages)
                {
                    string pngPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                    page.Save(pngPath, new PngOptions());
                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}