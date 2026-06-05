using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputBmp";
            string outputDirectory = @"C:\OutputSvg";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp", SearchOption.TopDirectoryOnly);
            if (bmpFiles.Length == 0)
            {
                Console.Error.WriteLine("No BMP files found to process.");
                return;
            }

            int index = 0;
            foreach (string bmpPath in bmpFiles)
            {
                // Check that the BMP file exists
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    continue;
                }

                // Create a timestamp prefix for uniqueness
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                // In case processing is very fast, add an index to guarantee uniqueness
                string prefix = $"{timestamp}_{index:D4}";
                index++;

                // Build the output SVG file path
                string outputFileName = $"{prefix}_{Path.GetFileNameWithoutExtension(bmpPath)}.svg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(bmpPath))
                {
                    // Prepare rasterization options matching the source image size
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Configure SVG export options
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions,
                        // Optional: keep metadata, compress, etc.
                        KeepMetadata = true,
                        Compress = false
                    };

                    // Save as SVG
                    image.Save(outputPath, svgOptions);
                }

                Console.WriteLine($"Converted: {bmpPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}