using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDir = "Input";
            string outputDir = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Process EMF files
            string[] emfFiles = Directory.GetFiles(inputDir, "*.emf");
            foreach (string inputPath in emfFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300); // Uniform DPI
                    image.Save(outputPath, pngOptions);
                }
            }

            // Process WMF files
            string[] wmfFiles = Directory.GetFiles(inputDir, "*.wmf");
            foreach (string inputPath in wmfFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300); // Uniform DPI
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a batch of legacy vector graphics (EMF and WMF) from a folder into high‑resolution PNGs for web display or documentation.
 * 2. When an application must standardize the DPI of mixed EMF/WMF assets to 300 DPI before embedding them into printable PDFs.
 * 3. When a migration tool has to transform old Windows Metafile illustrations into PNG thumbnails for a content management system.
 * 4. When an automated build process requires converting all vector icons in a source directory to PNG format with uniform resolution for cross‑platform UI assets.
 * 5. When a reporting service must generate PNG images from EMF and WMF charts stored on disk to send them via email or API responses.
 */