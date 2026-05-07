using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input SVG files
            string[] inputPaths = new[]
            {
                @"C:\Images\logo1.svg",
                @"C:\Images\logo2.svg"
            };

            // Desired icon sizes
            int[] iconSizes = new[] { 16, 32, 48, 256 };

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output .ico path (same folder, same name, .ico extension)
                string outputPath = Path.ChangeExtension(inputPath, ".ico");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Create an ICO image with the smallest size as the base
                    using (IcoImage icoImage = new IcoImage(iconSizes[0], iconSizes[0], new IcoOptions()))
                    {
                        foreach (int size in iconSizes)
                        {
                            // Prepare PNG save options with rasterization to the required size
                            var pngOptions = new PngOptions
                            {
                                VectorRasterizationOptions = new SvgRasterizationOptions
                                {
                                    PageSize = new Size(size, size)
                                }
                            };

                            // Rasterize SVG to PNG in memory
                            using (var ms = new MemoryStream())
                            {
                                svgImage.Save(ms, pngOptions);
                                ms.Position = 0;

                                // Load the rasterized PNG
                                using (Image rasterImage = Image.Load(ms))
                                {
                                    // Add the raster page to the ICO image
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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}