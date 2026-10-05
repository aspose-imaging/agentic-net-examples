// HOW-TO: Batch Convert BMP to SVG with Timestamped Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchBmpToSvg
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\InputBmp";
                string outputDirectory = @"C:\OutputSvg";

                // Get all BMP files in the input directory
                string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

                foreach (string inputPath in bmpFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Create a unique timestamp prefix
                    string timestamp = DateTime.UtcNow.Ticks.ToString();
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputFileName = $"{timestamp}_{fileNameWithoutExt}.svg";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load BMP and save as SVG
                    using (Image image = Image.Load(inputPath))
                    {
                        var svgOptions = new SvgOptions();
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically convert a folder of legacy BMP assets to scalable SVG graphics for web deployment while ensuring each file has a unique timestamped name.
 * 2. When a build pipeline must generate vector versions of raster icons and avoid filename collisions by prefixing outputs with a UTC tick value.
 * 3. When a desktop application processes user‑uploaded BMP screenshots and stores the resulting SVG files in a separate directory with unique identifiers for later retrieval.
 * 4. When a migration script has to batch‑convert legacy design files from BMP to SVG and keep an audit trail by embedding the conversion time in the filename.
 * 5. When you want to use Aspose.Imaging in C# to programmatically transform multiple BMP images into SVG format and guarantee that each output file is uniquely named without manual renaming.
 */
