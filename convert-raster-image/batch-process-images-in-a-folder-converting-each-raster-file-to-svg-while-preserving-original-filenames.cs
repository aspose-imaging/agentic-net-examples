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
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output folder exists (creates the directory if needed)
            Directory.CreateDirectory(outputFolder);

            // Define raster image extensions to process
            string[] rasterExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".tif", ".tiff", ".gif" };

            // Enumerate files in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder))
            {
                // Check if the file has a supported raster extension
                if (Array.IndexOf(rasterExtensions, Path.GetExtension(inputPath).ToLowerInvariant()) < 0)
                {
                    continue; // Skip unsupported files
                }

                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output SVG path preserving the original filename
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare vector rasterization options based on the source image size
                    VectorRasterizationOptions vectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Configure SVG save options
                    SvgOptions svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorRasterizationOptions,
                        // Optional: set compression to false for plain SVG
                        Compress = false
                    };

                    // Save the image as SVG
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