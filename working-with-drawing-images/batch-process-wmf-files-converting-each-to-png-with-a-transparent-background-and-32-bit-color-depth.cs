using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
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
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all WMF files
            string[] files = Directory.GetFiles(inputDir, "*.wmf");

            foreach (var inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image
                using (Image image = Image.Load(inputPath))
                {
                    var wmfImage = image as WmfImage;
                    if (wmfImage == null)
                    {
                        Console.Error.WriteLine($"Not a WMF image: {inputPath}");
                        continue;
                    }

                    // Configure PNG options with transparent background and 32‑bit color depth
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        VectorRasterizationOptions = new WmfRasterizationOptions
                        {
                            BackgroundColor = Color.Transparent,
                            PageSize = wmfImage.Size
                        }
                    };

                    // Save as PNG
                    wmfImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}