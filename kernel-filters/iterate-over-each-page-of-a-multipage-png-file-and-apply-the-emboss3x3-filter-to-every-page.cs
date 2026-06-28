using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage && multipageImage.PageCount > 0)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        if (multipageImage.Pages[i] is RasterImage page)
                        {
                            page.Filter(
                                page.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                        }
                    }
                }
                else if (image is RasterImage raster)
                {
                    raster.Filter(
                        raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                }

                var saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer wants to add a 3×3 emboss filter to every page of a multi‑page PNG (such as an animated PNG) to give the frames a raised‑edge appearance using Aspose.Imaging in C#.
 * 2. When a C# application must preprocess a multi‑page PNG document before printing, applying the Emboss3x3 convolution filter to each raster page to improve contrast and edge definition.
 * 3. When a software tool converts scanned multi‑page PNG files into stylized images, using Aspose.Imaging to iterate over each page and apply the emboss filter for a consistent artistic effect.
 * 4. When a web service receives multi‑page PNG uploads and needs to automatically enhance each page with an emboss effect before storing them, leveraging the Image.Load, IMultipageImage, and Filter methods in .NET.
 * 5. When a developer integrates Aspose.Imaging into a batch‑processing pipeline that processes large numbers of multi‑page PNG files, applying the Emboss3x3 filter to every page to create a uniform visual style across all images.
 */