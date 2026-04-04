using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG files
        string[] inputSvgPaths = new[]
        {
            @"C:\Icons\icon1.svg",
            @"C:\Icons\icon2.svg"
        };

        // Hardcoded output ICO directory
        string outputDirectory = @"C:\Icons\Converted";

        // Ensure the output directory exists (unconditional as per rules)
        Directory.CreateDirectory(outputDirectory);

        // Desired icon sizes (in pixels)
        int[] iconSizes = new[] { 16, 32, 48, 64, 128, 256 };

        foreach (string inputPath in inputSvgPaths)
        {
            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output ICO file path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".ico");

            // Ensure the output directory for this file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Create an ICO image with the maximum size (256) and default options
                var icoOptions = new IcoOptions(); // defaults to PNG format, 32 bpp
                using (var icoImage = new IcoImage(256, 256, icoOptions))
                {
                    foreach (int size in iconSizes)
                    {
                        // Prepare PNG save options with rasterization at the required size
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                PageSize = new Size(size, size)
                            }
                        };

                        // Rasterize SVG to PNG in a memory stream
                        using (var ms = new MemoryStream())
                        {
                            svgImage.Save(ms, pngOptions);
                            ms.Position = 0; // reset stream for reading

                            // Load the rasterized PNG as an Image
                            using (Image rasterImage = Image.Load(ms))
                            {
                                // Add the raster image as a page to the ICO
                                icoImage.AddPage(rasterImage);
                            }
                        }
                    }

                    // Save the assembled ICO file
                    icoImage.Save(outputPath);
                }
            }
        }
    }
}