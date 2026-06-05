using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Ensure input directory exists; if not, create and exit
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all files in input directory
            string[] files = Directory.GetFiles(inputDir);

            // Limit concurrency to avoid high memory usage
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 2 };

            Parallel.ForEach(files, parallelOptions, inputPath =>
            {
                // Verify the file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with same file name but .png extension
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists (unconditionally as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}