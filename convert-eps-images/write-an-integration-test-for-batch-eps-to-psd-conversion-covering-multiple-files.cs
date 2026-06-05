using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDir = @"C:\Test\EpsFiles";
            string outputDir = @"C:\Test\PsdOutputs";

            // Files to be processed
            string[] epsFiles = new string[]
            {
                Path.Combine(inputDir, "sample1.eps"),
                Path.Combine(inputDir, "sample2.eps"),
                Path.Combine(inputDir, "sample3.eps")
            };

            foreach (var inputPath in epsFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path (same name, .psd extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".psd");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image and convert to PSD
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    var psdOptions = new PsdOptions(); // default options
                    image.Save(outputPath, psdOptions);
                }
            }

            Console.WriteLine("Batch EPS to PSD conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}