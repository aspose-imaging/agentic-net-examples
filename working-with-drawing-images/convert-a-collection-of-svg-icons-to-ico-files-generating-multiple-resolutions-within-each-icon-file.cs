using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Icons\Svg";
            string outputDirectory = @"C:\Icons\Ico";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Define the SVG files to process
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            // Define the icon sizes to include in each ICO file
            int[] iconSizes = new[] { 16, 32, 48, 64, 128, 256 };

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Create a new ICO image with default options
                    using (IcoImage ico = new IcoImage(256, 256, new IcoOptions()))
                    {
                        foreach (int size in iconSizes)
                        {
                            // Prepare rasterization options for the current size
                            var rasterOptions = new SvgRasterizationOptions
                            {
                                PageSize = new Size(size, size)
                            };

                            // Set up PNG save options with the rasterization options
                            var pngOptions = new PngOptions
                            {
                                VectorRasterizationOptions = rasterOptions
                            };

                            // Rasterize SVG to PNG in memory
                            using (var ms = new MemoryStream())
                            {
                                svgImage.Save(ms, pngOptions);
                                ms.Position = 0; // Reset stream position for reading

                                // Load the rasterized PNG as an Image
                                using (Image rasterImage = Image.Load(ms))
                                {
                                    // Add the raster image as a page to the ICO
                                    ico.AddPage(rasterImage);
                                }
                            }
                        }

                        // Build output ICO file path
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                        string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".ico");

                        // Ensure the output directory exists (unconditional as per rules)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the ICO file
                        ico.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}