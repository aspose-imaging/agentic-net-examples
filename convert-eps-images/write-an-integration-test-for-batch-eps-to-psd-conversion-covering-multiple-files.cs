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
        // Define relative input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDir = Path.Combine(baseDir, "Input");
        string outputDir = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
        if (!Directory.Exists(inputDir))
        {
            Directory.CreateDirectory(inputDir);
            Console.WriteLine($"Input directory created at: {inputDir}. Add EPS files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Get all EPS files in the input directory
        string[] epsFiles = Directory.GetFiles(inputDir, "*.eps");

        foreach (string inputPath in epsFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Prepare the output PSD file path
            string outputFileName = Path.ChangeExtension(Path.GetFileName(inputPath), ".psd");
            string outputPath = Path.Combine(outputDir, outputFileName);

            // Ensure the output directory exists (in case of subfolders)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image and convert to PSD
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure PSD save options (default settings)
                PsdOptions psdOptions = new PsdOptions
                {
                    // Example: set color mode to RGB
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
                };

                // Save as PSD
                epsImage.Save(outputPath, psdOptions);
            }

            Console.WriteLine($"Converted '{Path.GetFileName(inputPath)}' to '{outputFileName}'.");
        }
    }
}