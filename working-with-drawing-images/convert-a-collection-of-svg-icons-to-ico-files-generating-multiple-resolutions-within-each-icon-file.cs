// HOW-TO: Convert Multiple SVG Icons to Multi‑Resolution ICO Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded SVG source files
            string[] svgPaths = { "icon1.svg", "icon2.svg" };

            // Desired icon resolutions
            int[] sizes = { 16, 32, 48, 64, 128, 256 };

            foreach (string svgPath in svgPaths)
            {
                // Validate input file existence
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    continue;
                }

                // Output ICO path (same name, .ico extension)
                string icoPath = Path.ChangeExtension(svgPath, ".ico");

                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(icoPath);
                Directory.CreateDirectory(string.IsNullOrWhiteSpace(outputDir) ? "." : outputDir);

                // ICO creation options (default PNG frames, 32 bpp)
                IcoOptions icoOptions = new IcoOptions();

                // Create an ICO image using the first size as canvas
                using (var icoImage = new Aspose.Imaging.FileFormats.Ico.IcoImage(sizes[0], sizes[0], icoOptions))
                {
                    foreach (int size in sizes)
                    {
                        // Rasterization options for the current size
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                        {
                            PageWidth = size,
                            PageHeight = size,
                            BackgroundColor = Color.White
                        };

                        // PNG save options that use the rasterization settings
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        // Temporary PNG file to hold the rasterized SVG
                        string tempPng = Path.GetTempFileName();

                        // Rasterize SVG to PNG
                        using (SvgImage svgImage = (SvgImage)Image.Load(svgPath))
                        {
                            svgImage.Save(tempPng, pngOptions);
                        }

                        // Load the rasterized PNG and add it as a frame to the ICO
                        using (RasterImage pngRaster = (RasterImage)Image.Load(tempPng))
                        {
                            icoImage.AddPage(pngRaster);
                        }

                        // Clean up the temporary file
                        File.Delete(tempPng);
                    }

                    // Save the multi‑resolution ICO file
                    icoImage.Save(icoPath);
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
 * 1. When you need to generate Windows application icons from a set of SVG assets, creating all required sizes in a single .ico file.
 * 2. When you want to automate batch conversion of brand logo SVGs into ICO files for desktop shortcuts or installers.
 * 3. When you must provide high‑DPI support by embedding 16‑256 pixel PNG frames inside an ICO for modern Windows displays.
 * 4. When you are building a CI/CD pipeline that prepares icon resources from vector designs before packaging a .NET application.
 * 5. When you need to ensure each ICO contains multiple resolutions without manually resizing images, using Aspose.Imaging’s rasterization and IcoOptions in C#.
 */
