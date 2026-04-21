using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input/Output directory setup
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

        // Get all EPS files
        string[] files = Directory.GetFiles(inputDirectory, "*.eps");

        foreach (var epsFilePath in files)
        {
            // Verify input file exists
            if (!File.Exists(epsFilePath))
            {
                Console.Error.WriteLine($"File not found: {epsFilePath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epsFilePath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            DateTime start = DateTime.Now;

            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(epsFilePath))
            {
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, pngOptions);
            }

            DateTime end = DateTime.Now;
            double durationMs = (end - start).TotalMilliseconds;
            Console.WriteLine($"Converted {epsFilePath} to {outputPath} in {durationMs} ms");
        }
    }
}