using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.emf");

        foreach (var inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".png");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                using (var pngOptions = new PngOptions())
                {
                    pngOptions.VectorRasterizationOptions = vectorOptions;
                    pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                    pngOptions.PngCompressionLevel = PngCompressionLevel.ZipLevel9;

                    image.Save(outputPath, pngOptions);
                }
            }
        }
    }
}