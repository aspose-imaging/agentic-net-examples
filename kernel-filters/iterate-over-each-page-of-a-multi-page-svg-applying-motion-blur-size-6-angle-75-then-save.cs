using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputBaseDir = "output";
            Directory.CreateDirectory(outputBaseDir);

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    using (Image page = multipage.Pages[i])
                    {
                        // Rasterize the page to a PNG in memory
                        using (MemoryStream ms = new MemoryStream())
                        {
                            PngOptions pngOptions = new PngOptions();
                            VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
                            {
                                PageSize = page.Size
                            };
                            pngOptions.VectorRasterizationOptions = rasterOptions;

                            page.Save(ms, pngOptions);
                            ms.Position = 0;

                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                // Apply motion Wiener filter (size 6, smooth 1.0, angle 75)
                                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(6, 1.0, 75.0));

                                string outputPath = Path.Combine(outputBaseDir, $"page_{i}.png");
                                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                                raster.Save(outputPath);
                            }
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