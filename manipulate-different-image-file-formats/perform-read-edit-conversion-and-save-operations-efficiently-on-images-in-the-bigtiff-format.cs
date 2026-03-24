using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input_big.tif";
        string outputPath = @"C:\Images\output_big.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var bigTiff = image as BigTiffImage;
            if (bigTiff == null)
            {
                Console.Error.WriteLine("The loaded image is not a BigTiffImage.");
                return;
            }

            bigTiff.Resize(2000, 2000);
            bigTiff.Grayscale();

            using (var options = new BigTiffOptions(TiffExpectedFormat.Default))
            {
                bigTiff.Save(outputPath, options);
            }
        }
    }
}