using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
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

        // Get all SVG files in the input directory
        string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

        foreach (string inputPath in svgFiles)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Prepare output JPEG path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
            // Ensure output directory for the file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with high quality and high resolution
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 95,
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as high-resolution JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
    }
}