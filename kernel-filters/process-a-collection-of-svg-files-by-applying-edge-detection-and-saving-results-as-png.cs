using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "InputSvgs";
            string outputDirectory = "OutputPngs";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all SVG files
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Set up rasterization options for SVG
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // PNG save options with vector rasterization
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Rasterize SVG to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load rasterized PNG as RasterImage
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Edge detection kernel (simple Laplacian)
                            double[,] kernel = new double[,]
                            {
                                { -1, -1, -1 },
                                { -1,  8, -1 },
                                { -1, -1, -1 }
                            };

                            // Apply convolution filter for edge detection
                            ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);
                            raster.Filter(raster.Bounds, filterOptions);

                            // Save the processed image as PNG
                            raster.Save(outputPath, new PngOptions());
                        }
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