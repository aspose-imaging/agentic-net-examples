// HOW-TO: Batch Apply Edge Detection to SVG Files and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputSvgs";
            string outputDirectory = "OutputPngs";

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

            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unable to rasterize SVG: {inputPath}");
                        continue;
                    }

                    double[,] customKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel));

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        raster.Save(outputPath, pngOptions);
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
 * 1. When you need to batch‑process SVG illustrations to produce edge‑detected PNGs for technical documentation.
 * 2. When converting a collection of SVG icons into high‑contrast PNGs that highlight their outlines for low‑resolution UI displays.
 * 3. When generating stylized thumbnails of SVG artwork by applying an edge‑detection filter and saving the results as PNG files.
 * 4. When preprocessing SVG diagrams with a convolution kernel to extract edges before feeding the images into a computer‑vision pipeline.
 * 5. When preparing SVG floor plans for print by rasterizing them, applying edge detection, and exporting the results as PNG images.
 */
