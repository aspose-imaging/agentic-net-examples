using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all ODG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.odg");

        foreach (string filePath in files)
        {
            // Validate input file existence
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                continue;
            }

            // Prepare output path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image asynchronously
            using (Image image = await Task.Run(() => Image.Load(filePath)))
            {
                // Configure BMP save options with rasterization settings
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    bmpOptions.VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    };

                    // Save the image as BMP asynchronously
                    await Task.Run(() => image.Save(outputPath, bmpOptions));
                }
            }

            Console.WriteLine($"Converted: {filePath} -> {outputPath}");
        }
    }
}