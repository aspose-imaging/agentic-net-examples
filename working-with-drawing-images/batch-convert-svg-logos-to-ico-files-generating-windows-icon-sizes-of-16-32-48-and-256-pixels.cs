using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\SvgInput";
            string outputFolder = @"C:\IcoOutput";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Define required icon sizes
            int[] iconSizes = new[] { 16, 32, 48, 256 };

            // Process each SVG file in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder, "*.svg"))
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
                    // Create an ICO image with the largest size (256) as base
                    var icoOptions = new IcoOptions(); // defaults to PNG format, 32 bpp
                    using (var icoImage = new IcoImage(256, 256, icoOptions))
                    {
                        // Generate and add each required size
                        foreach (int size in iconSizes)
                        {
                            // Set up rasterization options for the current size
                            var rasterizationOptions = new SvgRasterizationOptions
                            {
                                PageSize = new Size(size, size)
                            };

                            // Prepare PNG save options with the rasterization settings
                            var pngOptions = new PngOptions
                            {
                                VectorRasterizationOptions = rasterizationOptions
                            };

                            // Rasterize SVG to PNG in memory
                            using (var ms = new MemoryStream())
                            {
                                svgImage.Save(ms, pngOptions);
                                ms.Position = 0;

                                // Load the rasterized PNG as a RasterImage
                                using (RasterImage raster = (RasterImage)Image.Load(ms))
                                {
                                    // Add the raster page to the ICO image
                                    icoImage.AddPage(raster);
                                }
                            }
                        }

                        // Determine output ICO path
                        string outputPath = Path.Combine(outputFolder,
                            Path.GetFileNameWithoutExtension(inputPath) + ".ico");

                        // Ensure the output directory exists (unconditional as required)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the ICO file
                        icoImage.Save(outputPath);
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automate the creation of Windows .ico files from a collection of brand SVG logos for use in desktop applications, this batch conversion code can generate the required 16‑px, 32‑px, 48‑px, and 256‑px icon sizes.
 * 2. When a CI/CD pipeline must produce multi‑resolution icons from vector assets stored in a source repository, the Aspose.Imaging C# script can rasterize each SVG and bundle the PNG representations into a single .ico file.
 * 3. When a UI/UX team supplies scalable SVG icons and the development team must supply legacy Windows icons for legacy software installers, this code quickly converts all SVG files in a folder to the appropriate ICO format.
 * 4. When a developer is building a branding toolkit that needs to export corporate SVG logos as Windows icons for start‑menu shortcuts, the example shows how to iterate over files, set rasterization options, and save the icons with Aspose.Imaging.
 * 5. When an automated asset pipeline has to ensure that every SVG logo is available in the standard Windows icon resolutions for cross‑platform deployment, this C# batch process creates the 16, 32, 48, and 256 pixel ICO images in one step.
 */