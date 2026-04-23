using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] files = Directory.GetFiles(inputDirectory, "*.dng");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".tif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DngImage dng = (DngImage)Image.Load(inputPath))
                {
                    dng.Resize(1024, 768, ResizeType.NearestNeighbourResample);
                    dng.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}