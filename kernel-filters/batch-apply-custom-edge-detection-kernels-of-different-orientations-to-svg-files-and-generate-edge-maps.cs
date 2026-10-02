// HOW-TO: Batch Convert SVG to Edge Map PNG Using Custom Sobel Kernels in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[]
            {
                "input1.svg",
                "input2.svg"
            };
            string outputDirectory = "output";

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string tempPngPath = Path.Combine(outputDirectory, fileName + "_temp.png");
                string outputPath = Path.Combine(outputDirectory, fileName + "_edge.png");

                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Rasterize SVG to PNG
                using (Image svgImage = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    svgImage.Save(tempPngPath, pngOptions);
                }

                // Load raster image and apply edge detection kernels
                using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                {
                    double[,] kernelHorizontal = new double[,]
                    {
                        { -1, 0, 1 },
                        { -2, 0, 2 },
                        { -1, 0, 1 }
                    };

                    double[,] kernelVertical = new double[,]
                    {
                        { -1, -2, -1 },
                        {  0,  0,  0 },
                        {  1,  2,  1 }
                    };

                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernelHorizontal));
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernelVertical));

                    var outOptions = new PngOptions();
                    raster.Save(outputPath, outOptions);
                }

                // Clean up temporary file
                try
                {
                    File.Delete(tempPngPath);
                }
                catch
                {
                    // Ignore any errors during cleanup
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
 * 1. When you need to generate edge detection maps from a collection of SVG illustrations for computer‑vision preprocessing.
 * 2. When you want to rasterize vector graphics to PNG before applying Sobel filters in a .NET batch workflow.
 * 3. When you must automate the creation of horizontal and vertical edge images for feature extraction in machine‑learning pipelines.
 * 4. When you require a quick way to produce edge‑highlighted PNGs from SVG logos for UI thumbnails or visual analysis.
 * 5. When you are building a server‑side service that processes uploaded SVG files and returns edge‑detected PNGs for downstream image‑processing tasks.
 */
