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
            string inputFolder = @"C:\Icons\Svg";
            string outputFolder = @"C:\Icons\Ico";

            // List of SVG files to process
            string[] svgFiles = new[]
            {
                "icon1.svg",
                "icon2.svg",
                "icon3.svg"
            };

            // Desired icon resolutions
            int[] sizes = new[] { 16, 32, 48, 64, 128, 256 };

            foreach (string fileName in svgFiles)
            {
                string inputPath = Path.Combine(inputFolder, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Create an ICO image with the smallest size (required for constructor)
                    var icoOptions = new IcoOptions();
                    using (var ico = new IcoImage(sizes[0], sizes[0], icoOptions))
                    {
                        // Add each resolution as a page
                        foreach (int size in sizes)
                        {
                            // Rasterize SVG to the target size using PNG options
                            var rasterizationOptions = new SvgRasterizationOptions
                            {
                                PageSize = new Size(size, size)
                            };

                            var pngOptions = new PngOptions
                            {
                                VectorRasterizationOptions = rasterizationOptions
                            };

                            using (var ms = new MemoryStream())
                            {
                                // Save rasterized PNG to memory stream
                                svgImage.Save(ms, pngOptions);
                                ms.Position = 0;

                                // Load the rasterized PNG as an Image (RasterImage)
                                using (Image rasterImage = Image.Load(ms))
                                {
                                    // Add the raster page to the ICO
                                    ico.AddPage(rasterImage);
                                }
                            }
                        }

                        // Prepare output path and ensure directory exists
                        string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(fileName) + ".ico");
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate Windows application icons from a set of vector SVG assets, creating a single .ico file that contains 16‑256 px resolutions for proper display on different DPI settings.
 * 2. When a build pipeline must automatically convert a library of brand SVG symbols into multi‑size ICO files for inclusion in installer packages without manual image editing.
 * 3. When a web‑to‑desktop conversion tool requires rasterizing scalable SVG logos into a Windows icon bundle so that the resulting .ico works in taskbar, start menu, and file explorer.
 * 4. When a C# utility is needed to batch‑process design assets, turning designer‑provided SVG icons into compliant ICO files that Windows uses for shortcut icons across various screen resolutions.
 * 5. When an automated deployment script must ensure that each SVG icon in a resource folder is transformed into an .ico containing 16, 32, 48, 64, 128, and 256 pixel images for consistent appearance on high‑DPI monitors.
 */