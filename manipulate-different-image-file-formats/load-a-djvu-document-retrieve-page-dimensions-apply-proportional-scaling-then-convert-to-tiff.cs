using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.djvu";
        string outputPath = "Output\\scaled.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
        {
            int originalWidth = djvu.Width;
            int newWidth = originalWidth * 2;
            djvu.ResizeWidthProportionally(newWidth, ResizeType.NearestNeighbourResample);
            djvu.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
        }
    }
}