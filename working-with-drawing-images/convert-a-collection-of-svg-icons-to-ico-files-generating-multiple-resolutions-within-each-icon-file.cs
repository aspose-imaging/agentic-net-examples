using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "InputSvgs";
            string outputDirectory = "OutputIcos";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // List of SVG files to process
            string[] svgFiles = new[]
            {
                Path.Combine(inputDirectory, "icon1.svg"),
                Path.Combine(inputDirectory, "icon2.svg")
                // Add more SVG file names as needed
            };

            // Desired icon sizes (width and height are equal)
            int[] iconSizes = new[] { 16, 32, 48, 64, 128, 256 };

            foreach (string inputPath in svgFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output ICO path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".ico");

                // Ensure output directory exists (already created above, but keep rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    IcoImage icoImage = null;

                    foreach (int size in iconSizes)
                    {
                        // Set up rasterization options for the current size
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
                            ms.Position = 0;

                            // Load the rasterized PNG as a RasterImage
                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                if (icoImage == null)
                                {
                                    // Create the ICO image with the first frame
                                    icoImage = new IcoImage(raster.Width, raster.Height, new IcoOptions());
                                    // Add the first frame
                                    icoImage.AddPage(raster, new IcoOptions());
                                }
                                else
                                {
                                    // Add additional frames
                                    icoImage.AddPage(raster, new IcoOptions());
                                }
                            }
                        }
                    }

                    // Save the multi-resolution ICO file
                    icoImage.Save(outputPath);
                    icoImage.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a set of SVG icons into a single ICO file that contains multiple resolutions for Windows desktop shortcuts.
 * 2. When building a cross‑platform .NET application that must supply high‑DPI favicons by rasterizing vector SVG assets into 16‑256 px icon sizes inside an ICO container.
 * 3. When automating a CI/CD pipeline to generate Windows application icons from source SVG files, ensuring each .ico includes the required 16, 32, 48, 64, 128, and 256 pixel versions.
 * 4. When creating a branding toolkit where designers provide SVG logos and the development team must programmatically produce multi‑size .ico files for use in installers and start‑menu tiles.
 * 5. When migrating legacy bitmap icons to scalable vector graphics and need a C# script that reads SVG files, rasterizes them at several dimensions, and saves them as a single multi‑resolution ICO resource.
 */