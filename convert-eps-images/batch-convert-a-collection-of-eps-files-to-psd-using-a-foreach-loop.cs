using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded collection of EPS input files
        string[] inputFiles = new string[]
        {
            @"C:\Images\Input1.eps",
            @"C:\Images\Input2.eps",
            @"C:\Images\Input3.eps"
        };

        // Output directory (hardcoded)
        string outputDir = @"C:\Images\Converted";

        // Ensure the output directory exists (unconditional as per rules)
        Directory.CreateDirectory(outputDir);

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output file path with .psd extension
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".psd";
            string outputPath = Path.Combine(outputDir, outputFileName);

            // Ensure the directory for the output file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PSD save options
                var psdOptions = new PsdOptions
                {
                    // Example: set PSD version to PSD (default)
                    PsdVersion = Aspose.Imaging.FileFormats.Psd.PsdVersion.Psd
                };

                // Save as PSD
                image.Save(outputPath, psdOptions);
            }

            Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
        }
    }
}