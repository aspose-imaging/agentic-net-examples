using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Process all files in the input directory
            foreach (var inputPath in Directory.GetFiles(inputDirectory, "*.*"))
            {
                string ext = Path.GetExtension(inputPath);
                if (!ext.Equals(".tif", StringComparison.OrdinalIgnoreCase) &&
                    !ext.Equals(".tiff", StringComparison.OrdinalIgnoreCase))
                {
                    continue; // Skip non‑TIFF files
                }

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".webp");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (WebPOptions options = new WebPOptions())
                    {
                        // Example settings; adjust as needed
                        options.Lossless = false;
                        options.Quality = 80f;

                        image.Save(outputPath, options);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}