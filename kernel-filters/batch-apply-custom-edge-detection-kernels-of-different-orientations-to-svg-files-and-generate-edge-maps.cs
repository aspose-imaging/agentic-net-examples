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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (var filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (Image svgImage = Image.Load(filePath))
                {
                    var pngOptions = new PngOptions();
                    var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    byte[] pngData;
                    using (var ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        pngData = ms.ToArray();
                    }

                    double[,] kernelHorizontal = new double[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                    double[,] kernelVertical = new double[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
                    double[,] kernelDiagonal = new double[,] { { 0, 1, 2 }, { -1, 0, 1 }, { -2, -1, 0 } };

                    // Horizontal edge map
                    using (RasterImage raster = (RasterImage)Image.Load(new MemoryStream(pngData)))
                    {
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernelHorizontal));
                        string outPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + "_horizontal.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                        raster.Save(outPath, new PngOptions());
                    }

                    // Vertical edge map
                    using (RasterImage raster = (RasterImage)Image.Load(new MemoryStream(pngData)))
                    {
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernelVertical));
                        string outPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + "_vertical.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                        raster.Save(outPath, new PngOptions());
                    }

                    // Diagonal edge map
                    using (RasterImage raster = (RasterImage)Image.Load(new MemoryStream(pngData)))
                    {
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernelDiagonal));
                        string outPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + "_diagonal.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                        raster.Save(outPath, new PngOptions());
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
 * 1. When a developer needs to automatically extract horizontal, vertical, and diagonal edges from a collection of SVG icons to create high‑contrast thumbnails for a web catalog, they can use this code to rasterize each SVG to PNG, apply custom convolution kernels, and save the edge maps.
 * 2. When a GIS application must generate contour‑like edge overlays from vector map symbols stored as SVG files for faster rendering on low‑bandwidth devices, this batch processing routine provides the C# workflow to convert, filter, and output PNG edge maps.
 * 3. When a machine‑learning pipeline requires pre‑processed edge images from SVG diagrams as training data for a shape‑recognition model, the code enables developers to rasterize the vectors and apply oriented Sobel‑like kernels in one pass.
 * 4. When an e‑learning platform wants to highlight structural lines in SVG‑based technical drawings for interactive quizzes, the script can batch‑process the drawings, produce horizontal, vertical, and diagonal edge maps, and store them as PNG assets.
 * 5. When a quality‑control tool needs to detect missing or broken strokes in batch‑uploaded SVG logos by comparing edge maps against a reference, this C# example shows how to generate the necessary edge detection images using Aspose.Imaging’s convolution filters.
 */