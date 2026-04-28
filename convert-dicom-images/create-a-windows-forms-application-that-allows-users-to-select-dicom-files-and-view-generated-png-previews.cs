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
            string inputPath = "Input\\sample.dcm";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    using (PngOptions options = new PngOptions())
                    {
                        page.Save(outputPath, options);
                    }
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