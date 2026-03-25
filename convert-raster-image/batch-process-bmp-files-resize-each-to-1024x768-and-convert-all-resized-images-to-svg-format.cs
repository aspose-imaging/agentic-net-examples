using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

        // Get all BMP files in the input directory
        string[] files = Directory.GetFiles(inputDir, "*.bmp");

        foreach (var inputPath in files)
        {
            // Input file existence check (must return on missing file)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output SVG path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768 using nearest neighbour resampling
                image.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                // Set up SVG export options
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                    rasterOptions.PageSize = image.Size;
                    svgOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the resized image as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
    }
}