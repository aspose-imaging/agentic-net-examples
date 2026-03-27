using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded relative input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all JPEG2000 files (jp2 and j2k) in the input directory
        var files = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
        var jp2Files = Array.FindAll(files, f =>
            f.EndsWith(".jp2", StringComparison.OrdinalIgnoreCase) ||
            f.EndsWith(".j2k", StringComparison.OrdinalIgnoreCase));

        // Process files in parallel
        System.Threading.Tasks.Parallel.ForEach(jp2Files, inputPath =>
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path (PNG conversion)
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".png");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG2000 image with memory‑optimized options
            using (var image = Image.Load(
                inputPath,
                new Aspose.Imaging.ImageLoadOptions.Jpeg2000LoadOptions { ConcurrentImageProcessing = true }))
            {
                // Save as PNG
                image.Save(outputPath, new PngOptions());
            }
        });
    }
}