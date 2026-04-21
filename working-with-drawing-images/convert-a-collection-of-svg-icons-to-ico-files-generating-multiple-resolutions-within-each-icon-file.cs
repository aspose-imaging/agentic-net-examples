using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "InputSvgs";
        string outputDirectory = "OutputIcos";

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all SVG files in the input directory
        string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

        foreach (string svgPath in svgFiles)
        {
            // Validate input file existence
            if (!File.Exists(svgPath))
            {
                Console.Error.WriteLine($"File not found: {svgPath}");
                return;
            }

            // Prepare output ICO path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(svgPath) + ".ico");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image vectorImage = Image.Load(svgPath))
            {
                // ICO creation options (default 32bpp PNG frames)
                IcoOptions icoOptions = new IcoOptions();

                // Create an ICO image with the largest required size (256x256)
                using (IcoImage ico = new IcoImage(256, 256, icoOptions))
                {
                    // Desired icon resolutions
                    int[] sizes = new int[] { 16, 32, 48, 256 };

                    foreach (int size in sizes)
                    {
                        // Rasterization options for the current size
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                        {
                            PageWidth = size,
                            PageHeight = size,
                            BackgroundColor = Color.White
                        };

                        // PNG save options using the rasterization settings
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        // Rasterize SVG to PNG in memory
                        using (MemoryStream ms = new MemoryStream())
                        {
                            vectorImage.Save(ms, pngOptions);
                            ms.Position = 0;

                            // Load the rasterized PNG as a RasterImage
                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                // Add the raster image as a frame to the ICO
                                ico.AddPage(raster);
                            }
                        }
                    }

                    // Save the assembled ICO file
                    ico.Save(outputPath);
                }
            }

            Console.WriteLine($"Converted '{svgPath}' to ICO '{outputPath}'.");
        }
    }
}