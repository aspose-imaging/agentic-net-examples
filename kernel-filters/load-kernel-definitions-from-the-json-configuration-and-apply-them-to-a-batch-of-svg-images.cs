using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input/Output directory setup (atomic block)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            // Load kernel definitions from JSON configuration (simple name list)
            string kernelConfigPath = Path.Combine(inputDirectory, "kernels.json");
            if (!File.Exists(kernelConfigPath))
            {
                Console.Error.WriteLine($"File not found: {kernelConfigPath}");
                return;
            }

            List<string> kernelNames = new List<string>();
            foreach (string line in File.ReadAllLines(kernelConfigPath))
            {
                if (line.Contains("Emboss3x3")) kernelNames.Add("Emboss3x3");
                if (line.Contains("Emboss5x5")) kernelNames.Add("Emboss5x5");
                if (line.Contains("Sharpen3x3")) kernelNames.Add("Sharpen3x3");
                if (line.Contains("Sharpen5x5")) kernelNames.Add("Sharpen5x5");
            }

            if (kernelNames.Count == 0)
            {
                Console.Error.WriteLine("No kernel definitions found in configuration.");
                return;
            }

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                if (!filePath.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                {
                    // Skip non‑SVG files
                    continue;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(filePath) + "_filtered.png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(filePath))
                {
                    // Rasterize SVG to PNG in memory
                    var rasterOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (Image rasterImage = Image.Load(ms))
                        {
                            var raster = (RasterImage)rasterImage;

                            // Apply each kernel from configuration
                            foreach (string name in kernelNames)
                            {
                                double[,] kernel = null;
                                switch (name)
                                {
                                    case "Emboss3x3":
                                        kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
                                        break;
                                    case "Emboss5x5":
                                        kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5;
                                        break;
                                    case "Sharpen3x3":
                                        kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3;
                                        break;
                                    case "Sharpen5x5":
                                        kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen5x5;
                                        break;
                                }

                                if (kernel != null)
                                {
                                    var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 0.0, 1);
                                    raster.Filter(raster.Bounds, convOptions);
                                }
                            }

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