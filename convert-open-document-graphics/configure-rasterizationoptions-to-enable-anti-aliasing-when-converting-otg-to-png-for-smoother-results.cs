using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var otgRasterOptions = new Aspose.Imaging.ImageOptions.OtgRasterizationOptions
                {
                    PageSize = image.Size,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
                };

                using (var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions())
                {
                    pngOptions.VectorRasterizationOptions = otgRasterOptions;
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}