using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            // Ensure input directory exists
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

            var files = Directory.GetFiles(inputDir, "*.*")
                .Where(f => f.EndsWith(".emf", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PNG options with uniform DPI
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.ResolutionSettings = new ResolutionSetting(300, 300); // uniform DPI

                    // Set appropriate vector rasterization options based on file type
                    if (inputPath.EndsWith(".emf", StringComparison.OrdinalIgnoreCase))
                    {
                        var rasterOptions = new EmfRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageSize = image.Size
                        };
                        pngOptions.VectorRasterizationOptions = rasterOptions;
                    }
                    else // .wmf
                    {
                        var rasterOptions = new WmfRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageSize = image.Size
                        };
                        pngOptions.VectorRasterizationOptions = rasterOptions;
                    }

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