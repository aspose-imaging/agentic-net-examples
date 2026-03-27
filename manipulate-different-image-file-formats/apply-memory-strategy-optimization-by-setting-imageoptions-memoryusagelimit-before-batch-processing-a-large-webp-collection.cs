using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        string[] files = Directory.GetFiles(inputDirectory, "*.webp");

        foreach (var file in files)
        {
            string inputPath = file;
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (var options = new PngOptions())
                {
                    options.BufferSizeHint = 50;
                    image.Save(outputPath, options);
                }
            }
        }
    }
}