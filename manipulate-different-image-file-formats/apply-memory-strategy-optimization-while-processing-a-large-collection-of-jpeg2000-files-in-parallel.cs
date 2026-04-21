using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded relative input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Get all JPEG2000 files in the input directory
        string[] inputFiles = Directory.GetFiles(inputDirectory, "*.jp2");

        // Parallel processing options (limit degree of parallelism for memory safety)
        var parallelOptions = new System.Threading.Tasks.ParallelOptions
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount
        };

        // Process each file in parallel
        System.Threading.Tasks.Parallel.ForEach(inputFiles, parallelOptions, inputPath =>
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output path (same name with .png extension)
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG2000 image, convert and save as PNG
            using (Jpeg2000Image jpegImage = new Jpeg2000Image(inputPath))
            {
                jpegImage.Save(outputPath, new PngOptions());
            }
        });
    }
}