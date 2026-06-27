using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.apng";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                if (image is ApngImage apngImage)
                {
                    int pageCount = apngImage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        using (RasterImage raster = (RasterImage)apngImage.Pages[i])
                        {
                            double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(5, 225);
                            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                            raster.Filter(raster.Bounds, filterOptions);

                            string outputPath = $"output\\page{i + 1}.png";
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            var pngOptions = new PngOptions();
                            raster.Save(outputPath, pngOptions);
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multi-page APNG.");
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
 * 1. When a developer needs to extract each frame from an animated PNG (APNG), apply a 5‑pixel motion blur at a 225° angle using a convolution filter, and save the frames as separate PNG files.
 * 2. When a developer wants to preprocess multi‑page APNG images by applying a directional blur effect before converting each page to a static PNG for a slideshow presentation.
 * 3. When a developer is building a .NET image‑processing pipeline that must apply a custom convolution kernel to every page of an APNG and export the results as individual PNG images.
 * 4. When a developer must generate blurred thumbnail PNGs from each frame of an APNG automatically, using Aspose.Imaging’s GetBlurMotion filter for consistent visual styling.
 * 5. When a developer needs to automate batch processing of animated PNG files, applying a motion blur convolution filter to each page and saving the output pages as separate PNG files for further analysis or publishing.
 */