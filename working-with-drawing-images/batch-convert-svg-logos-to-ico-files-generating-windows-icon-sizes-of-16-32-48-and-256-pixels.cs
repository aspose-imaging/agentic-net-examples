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
            // Hard‑coded input SVG files
            string[] inputFiles = new[]
            {
                @"C:\Logos\logo1.svg",
                @"C:\Logos\logo2.svg"
            };

            // Hard‑coded output directory (ICO files will be placed here)
            string outputDir = @"C:\Icons";

            // Ensure the output directory exists (unconditional as required)
            Directory.CreateDirectory(outputDir);

            // Desired icon sizes
            int[] iconSizes = new[] { 16, 32, 48, 256 };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path (same file name, .ico extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".ico");

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Create an empty ICO image with the largest size (256) – this defines the canvas
                    using (IcoImage icoImage = new IcoImage(256, 256, new IcoOptions()))
                    {
                        foreach (int size in iconSizes)
                        {
                            // Set up rasterization options for the current size
                            var rasterizationOptions = new SvgRasterizationOptions
                            {
                                PageSize = new Size(size, size)
                            };

                            // Use PNG options with the rasterization settings
                            var pngOptions = new PngOptions
                            {
                                VectorRasterizationOptions = rasterizationOptions
                            };

                            // Rasterize the SVG to a PNG stored in memory
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

                        // Save the assembled ICO file
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
 * 1. When a developer needs to generate Windows application icons from a set of brand SVG logos for multiple resolutions (16, 32, 48, 256 px) in an automated C# build process.
 * 2. When a CI/CD pipeline must convert newly added SVG assets into .ico files so that desktop installers can include proper icons without manual resizing.
 * 3. When a UI team wants to batch‑process SVG icons stored in a folder and output .ico files ready for use in Windows shortcut files or taskbar pins.
 * 4. When a software vendor must ensure that every SVG logo in their repository is available as a multi‑size ICO for legacy Windows versions and high‑DPI displays.
 * 5. When an internal tool needs to read SVG files, rasterize them at standard icon dimensions, and save them to a designated output directory for automatic inclusion in a Windows resource file.
 */