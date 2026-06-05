using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        RasterImage page = (RasterImage)multipageImage.Pages[i];
                        page.Filter(page.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                    }
                }
                else if (image is RasterImage rasterImage)
                {
                    rasterImage.Filter(rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                }

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, options);
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
 * 1. When a developer needs to add a 3×3 emboss effect to every frame of a multi‑page PNG (such as an animated PNG) before saving it for web display.
 * 2. When an image‑processing pipeline must automatically enhance scanned document pages stored in a single PNG file by applying a convolution emboss filter to improve edge visibility.
 * 3. When a desktop application generates stylized thumbnails for each page of a multi‑page PNG atlas and wants to apply the Emboss3x3 filter to give a raised‑relief look.
 * 4. When a batch conversion tool processes both single‑page and multi‑page PNG files and needs a consistent C# routine that applies the same emboss filter to all pages before exporting.
 * 5. When a reporting system extracts individual pages from a multi‑page PNG chart and applies the Emboss3x3 convolution to highlight data contours before embedding the images in PDF reports.
 */