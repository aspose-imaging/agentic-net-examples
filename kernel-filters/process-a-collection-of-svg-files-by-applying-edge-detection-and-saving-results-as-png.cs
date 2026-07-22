using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            double[,] sobelKernel = new double[,]
                            {
                                { -1, 0, 1 },
                                { -2, 0, 2 },
                                { -1, 0, 1 }
                            };

                            var filterOptions = new ConvolutionFilterOptions(sobelKernel);
                            raster.Filter(raster.Bounds, filterOptions);

                            var saveOptions = new PngOptions();
                            raster.Save(outputPath, saveOptions);
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
 * 1. When a developer must batch‑convert SVG illustrations to PNG images while applying edge detection to highlight outlines for a web gallery.
 * 2. When an automated build process needs to generate PNG previews of SVG assets with edge detection filters for visual regression testing.
 * 3. When a data‑science workflow requires extracting edge‑enhanced PNG versions of SVG diagrams to feed into a computer‑vision model.
 * 4. When a reporting system has to embed SVG charts as PNG files with edge detection applied to improve readability in printed PDFs.
 * 5. When a desktop utility needs to process a folder of SVG logos, run an edge detection convolution, and save the results as PNG files for offline use.
 */