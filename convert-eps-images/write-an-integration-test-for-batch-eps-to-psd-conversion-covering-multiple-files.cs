using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        // Base directory of the application
        string baseDir = Directory.GetCurrentDirectory();
        // Input and output folders (relative to base directory)
        string inputDir = Path.Combine(baseDir, "Input");
        string outputDir = Path.Combine(baseDir, "Output");

        // List of EPS files to convert
        string[] epsFiles = new string[] { "sample1.eps", "sample2.eps", "sample3.eps" };

        foreach (var fileName in epsFiles)
        {
            // Build full input path and verify existence
            string inputPath = Path.Combine(inputDir, fileName);
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build full output path (change extension to .psd)
            string outputPath = Path.Combine(outputDir, Path.ChangeExtension(fileName, ".psd"));
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and convert to PSD
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure PSD saving options
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb
                };

                // Save as PSD
                epsImage.Save(outputPath, psdOptions);
            }
        }

        Console.WriteLine("Batch EPS to PSD conversion completed.");
    }
}