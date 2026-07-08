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
            string inputDirectory = @"C:\InputSvgs";
            string outputDirectory = @"C:\OutputIcos";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output ICO path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".ico");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Create an ICO image with the largest size (256) and default options
                    IcoOptions icoOptions = new IcoOptions();
                    using (IcoImage icoImage = new IcoImage(256, 256, icoOptions))
                    {
                        // Desired icon sizes
                        int[] iconSizes = { 16, 32, 48, 256 };

                        foreach (int size in iconSizes)
                        {
                            // Set up PNG save options with vector rasterization at the required size
                            PngOptions pngOptions = new PngOptions();
                            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                            {
                                PageSize = new Size(size, size)
                            };
                            pngOptions.VectorRasterizationOptions = rasterOptions;

                            // Rasterize SVG to PNG in memory
                            using (MemoryStream ms = new MemoryStream())
                            {
                                svgImage.Save(ms, pngOptions);
                                ms.Position = 0;

                                // Load the rasterized PNG
                                using (Image rasterImage = Image.Load(ms))
                                {
                                    // Add the raster image as a page to the ICO
                                    icoImage.AddPage(rasterImage);
                                }
                            }
                        }

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
 * 1. When a developer needs to batch‑convert a library of SVG brand logos into Windows ICO files with 16, 32, 48, and 256 pixel sizes for inclusion in application installers using C# and Aspose.Imaging.
 * 2. When an IT team automates the creation of multi‑size favicon.ico files from SVG assets so web sites can also provide desktop shortcut icons without manual resizing.
 * 3. When a software vendor generates high‑resolution (256 px) and legacy (16‑48 px) icons for a suite of desktop tools by loading SVG images and saving them as ICO files in a .NET build script.
 * 4. When a CI/CD pipeline must convert newly added SVG icons into Windows‑compatible ICO files to keep the product’s UI assets up‑to‑date without human intervention.
 * 5. When a designer delivers vector SVG icons and the development team uses Aspose.Imaging for .NET to batch‑process them into multi‑size ICO files for start‑menu tiles and task‑bar shortcuts.
 */