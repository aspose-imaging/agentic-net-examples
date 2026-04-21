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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage && multipageImage.PageCount > 0)
                {
                    foreach (Image page in multipageImage.Pages)
                    {
                        using (page)
                        {
                            if (page is RasterImage rasterPage)
                            {
                                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                                rasterPage.Filter(rasterPage.Bounds, filterOptions);
                            }
                        }
                    }
                }
                else if (image is RasterImage rasterImage)
                {
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                    rasterImage.Filter(rasterImage.Bounds, filterOptions);
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