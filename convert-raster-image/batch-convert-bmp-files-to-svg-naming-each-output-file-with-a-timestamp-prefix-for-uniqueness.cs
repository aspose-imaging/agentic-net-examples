using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDir = "Input";
        string outputDir = "Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Get all BMP files in the input directory
        string[] bmpFiles = Directory.GetFiles(inputDir, "*.bmp");

        foreach (string inputPath in bmpFiles)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Generate timestamped output file name
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string outputFileName = $"{timestamp}_{Path.GetFileNameWithoutExtension(inputPath)}.svg";
            string outputPath = Path.Combine(outputDir, outputFileName);

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG rasterization options
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Prepare SVG save options
                using (var svgOptions = new SvgOptions())
                {
                    svgOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
    }
}