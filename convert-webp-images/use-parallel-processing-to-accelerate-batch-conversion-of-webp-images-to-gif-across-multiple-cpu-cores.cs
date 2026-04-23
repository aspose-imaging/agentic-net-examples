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

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all WebP files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.webp");

        // Process files in parallel
        System.Threading.Tasks.Parallel.ForEach(files, inputPath =>
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output file path
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".gif");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image and save as GIF
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new GifOptions());
            }
        });
    }
}