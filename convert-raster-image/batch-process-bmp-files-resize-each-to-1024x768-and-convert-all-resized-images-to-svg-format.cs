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

        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!string.Equals(Path.GetExtension(inputPath), ".bmp", StringComparison.OrdinalIgnoreCase))
                continue;

            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(1024, 768);
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                image.Save(outputPath, svgOptions);
            }
        }
    }
}