using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cdr";
        string outputPath = "sample.psd";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            PsdOptions exportOptions = new PsdOptions();
            exportOptions.VectorRasterizationOptions = new CdrRasterizationOptions
            {
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            image.Save(outputPath, exportOptions);
        }
    }
}