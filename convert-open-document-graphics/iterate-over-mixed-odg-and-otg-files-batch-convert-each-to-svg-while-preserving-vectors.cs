using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Collect all ODG and OTG files
        var allFiles = Directory.GetFiles(inputDirectory, "*.*")
            .Where(f => f.EndsWith(".odg", StringComparison.OrdinalIgnoreCase) ||
                        f.EndsWith(".otg", StringComparison.OrdinalIgnoreCase))
            .ToArray();

        foreach (var inputPath in allFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path with .svg extension
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image (ODG or OTG)
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };
                    svgOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG preserving vectors
                    image.Save(outputPath, svgOptions);
                }
            }
        }
    }
}