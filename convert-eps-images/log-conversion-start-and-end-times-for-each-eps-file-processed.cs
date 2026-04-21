using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Eps;

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
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add EPS files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.eps");

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            DateTime startTime = DateTime.Now;
            Console.WriteLine($"Processing {Path.GetFileName(inputPath)} started at {startTime}");

            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
            }

            DateTime endTime = DateTime.Now;
            Console.WriteLine($"Processing {Path.GetFileName(inputPath)} finished at {endTime}. Duration: {endTime - startTime}");
        }
    }
}