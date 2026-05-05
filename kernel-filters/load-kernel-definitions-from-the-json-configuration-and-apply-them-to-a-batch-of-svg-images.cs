using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
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
            // Hardcoded paths
            string jsonConfigPath = "kernels.json";
            string inputFolder = "input_svgs";
            string outputFolder = "output_pngs";

            // Verify JSON configuration file
            if (!File.Exists(jsonConfigPath))
            {
                Console.Error.WriteLine($"File not found: {jsonConfigPath}");
                return;
            }

            // Load kernel definitions (dictionary: name -> 2D array)
            string json = File.ReadAllText(jsonConfigPath);
            var kernels = JsonSerializer.Deserialize<Dictionary<string, double[][]>>(json);
            if (kernels == null || kernels.Count == 0)
            {
                Console.Error.WriteLine("No kernels found in configuration.");
                return;
            }

            // Process each SVG file in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            foreach (var svgPath in svgFiles)
            {
                // Load SVG image
                using (Image svgImage = Image.Load(svgPath))
                {
                    // Rasterization options for SVG -> raster image
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Rasterize SVG into a memory stream
                    using (MemoryStream rasterStream = new MemoryStream())
                    {
                        svgImage.Save(rasterStream, pngOptions);
                        rasterStream.Position = 0;

                        // Load rasterized image as RasterImage
                        using (Image rasterImg = Image.Load(rasterStream))
                        {
                            RasterImage raster = (RasterImage)rasterImg;

                            // Apply each kernel from the configuration
                            foreach (var kvp in kernels)
                            {
                                double[][] kernel2D = kvp.Value;
                                int rows = kernel2D.Length;
                                int cols = kernel2D[0].Length;
                                double[,] kernel = new double[rows, cols];
                                for (int i = 0; i < rows; i++)
                                    for (int j = 0; j < cols; j++)
                                        kernel[i, j] = kernel2D[i][j];

                                var convOptions = new ConvolutionFilterOptions(kernel);
                                raster.Filter(raster.Bounds, convOptions);
                            }

                            // Prepare output path and ensure directory exists
                            string fileName = Path.GetFileNameWithoutExtension(svgPath);
                            string outputPath = Path.Combine(outputFolder, fileName + ".png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the filtered raster image as PNG
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