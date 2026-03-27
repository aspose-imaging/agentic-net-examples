using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");
        int counter = 1;

        foreach (string emfPath in emfFiles)
        {
            if (!File.Exists(emfPath))
            {
                Console.Error.WriteLine($"File not found: {emfPath}");
                return;
            }

            string outputPath = Path.Combine(outputDirectory, $"{counter}.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(emfPath))
            {
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                using (PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = rasterOptions
                })
                {
                    image.Save(outputPath, pngOptions);
                }
            }

            counter++;
        }
    }
}