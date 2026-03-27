using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.djvu";
        string outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            var exportArea = new Rectangle(100, 100, 200, 200);
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(0, exportArea);
            djvuImage.Save(outputPath, tiffOptions);
        }
    }
}