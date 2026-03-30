using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        Directory.CreateDirectory(outputDirectory);

        string[] files = Directory.GetFiles(inputDirectory);

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputDirectory,
                Path.GetFileNameWithoutExtension(inputPath) + "_processed.png");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.AdjustBrightness(10);

                using (var pngOptions = new PngOptions())
                {
                    raster.Save(outputPath, pngOptions);
                }
            }

            Console.WriteLine($"Processed: {inputPath} -> {outputPath}");
        }
    }
}