using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
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

        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (var inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            using (var image = Aspose.Imaging.Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, saveOptions);
            }

            stopwatch.Stop();
            Console.WriteLine($"Converted {inputPath} to {outputPath} in {stopwatch.ElapsedMilliseconds} ms");

            var fileInfo = new FileInfo(outputPath);
            Console.WriteLine($"Output file size: {fileInfo.Length} bytes");
        }
    }
}