using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image vectorImage = Image.Load(inputPath))
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = vectorImage.Size
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    using (MemoryStream ms = new MemoryStream())
                    {
                        vectorImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            double[,] kernel = new double[,]
                            {
                                { -1, -1, -1 },
                                {  0,  0,  0 },
                                {  1,  1,  1 }
                            };
                            var convOptions = new ConvolutionFilterOptions(kernel);
                            raster.Filter(raster.Bounds, convOptions);

                            var outPngOptions = new PngOptions();
                            raster.Save(outputPath, outPngOptions);
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a folder of SVG icons into high‑contrast PNG thumbnails with edge detection for a web UI, they can use this Aspose.Imaging C# routine.
 * 2. When an e‑learning platform must transform vector diagrams into raster PNG slides that highlight outlines for better readability on low‑resolution screens, this code automates the process.
 * 3. When a GIS application requires extracting the edges of SVG map layers and saving them as PNG overlays for further spatial analysis, the sample provides a ready‑to‑use solution.
 * 4. When a machine‑learning pipeline needs a large set of PNG images with detected edges from SVG training data, the program efficiently rasterizes and filters each file in C#.
 * 5. When a print‑to‑web workflow must generate PNG previews of SVG artwork with edge detection to verify line quality before publishing, this code handles the batch processing.
 */