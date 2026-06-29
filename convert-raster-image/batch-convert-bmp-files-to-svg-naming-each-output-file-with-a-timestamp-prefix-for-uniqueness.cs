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
            // Define input and output directories (relative to the current directory)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            // Get all BMP files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.bmp");

            foreach (string inputPath in files)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build a unique output file name with a timestamp prefix
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string outputFileName = $"{timestamp}_{fileNameWithoutExt}.svg";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image and save it as SVG
                using (Image image = Image.Load(inputPath))
                {
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };

                    image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to migrate a legacy collection of BMP icons to scalable SVG graphics for a web UI while ensuring each output file has a unique timestamped name to avoid overwriting.
 * 2. When an automated build pipeline must convert newly generated BMP screenshots into SVG format for documentation generation, and the timestamp prefix helps track when each conversion occurred.
 * 3. When a desktop application processes user‑uploaded BMP drawings in bulk and saves them as SVG files with timestamped filenames to maintain version history and prevent name collisions.
 * 4. When a server‑side service periodically scans an input folder for BMP assets, converts them to SVG for responsive design, and uses the timestamp prefix to create audit‑ready filenames.
 * 5. When a migration script needs to archive BMP assets into an SVG archive, naming each file with a precise timestamp to simplify sorting and retrieval in a content‑management system.
 */