using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input SVG files
            string[] inputFiles = new[]
            {
                @"C:\Icons\icon1.svg",
                @"C:\Icons\icon2.svg",
                @"C:\Icons\icon3.svg"
            };

            // Desired icon resolutions
            int[] sizes = new[] { 16, 32, 48, 64, 128, 256 };

            // Output folder for ICO files
            string outputFolder = @"C:\Icons\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            foreach (string inputPath in inputFiles)
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
                    // Create an ICO image with the maximum size (256x256) and default options
                    IcoOptions icoOptions = new IcoOptions();
                    using (IcoImage ico = new IcoImage(256, 256, icoOptions))
                    {
                        // Add a page for each required size
                        foreach (int size in sizes)
                        {
                            // Rasterize SVG to PNG at the required size using a memory stream
                            using (MemoryStream pngStream = new MemoryStream())
                            {
                                // Configure rasterization options for the target size
                                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                                {
                                    PageSize = new Size(size, size)
                                };

                                // Set up PNG save options with the rasterization settings
                                PngOptions pngOptions = new PngOptions
                                {
                                    VectorRasterizationOptions = rasterOptions
                                };

                                // Save rasterized PNG to the memory stream
                                svgImage.Save(pngStream, pngOptions);
                                pngStream.Position = 0; // Reset stream position for reading

                                // Load the rasterized PNG as an Image
                                using (Image rasterImage = Image.Load(pngStream))
                                {
                                    // Add the raster image as a page in the ICO
                                    ico.AddPage(rasterImage);
                                }
                            }
                        }

                        // Determine output ICO path (same name as SVG but .ico extension)
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                        string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".ico");

                        // Ensure the directory for the output file exists (already created above)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the ICO file
                        ico.Save(outputPath);
                        Console.WriteLine($"Created ICO: {outputPath}");
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
 * 1. When a developer needs to convert a set of vector SVG icons into Windows ICO files that contain multiple resolutions (16‑256 px) for use as application or shortcut icons.
 * 2. When building an automated build pipeline that generates high‑quality multi‑size ICO assets from design‑team SVG files to ensure crisp icons on high‑DPI displays.
 * 3. When creating a desktop installer that must bundle icons in the ICO format, requiring on‑the‑fly rasterization of SVG resources into the required 16, 32, 48, 64, 128, and 256 pixel images.
 * 4. When a SaaS platform offers custom branding and needs to transform user‑uploaded SVG logos into ICO files that Windows Explorer can display at any supported size.
 * 5. When a C# utility must batch‑process a folder of SVG symbols and produce corresponding ICO files with all standard Windows icon sizes, using Aspose.Imaging’s SvgRasterizationOptions and IcoImage classes.
 */