using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path
        string inputPath = @"C:\Images\multipage.png";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the multi‑page PNG
        using (Image image = Image.Load(inputPath))
        {
            IMultipageImage multipage = image as IMultipageImage;
            if (multipage == null)
            {
                Console.Error.WriteLine("The loaded image is not a multipage image.");
                return;
            }

            // Custom 3×3 kernel whose sum equals 1 (simple blur)
            double[,] kernel = new double[,]
            {
                { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
            };
            var filterOptions = new ConvolutionFilterOptions(kernel);

            // Process each page
            for (int i = 0; i < multipage.PageCount; i++)
            {
                // Each page is a RasterImage
                using (RasterImage page = (RasterImage)multipage.Pages[i])
                {
                    // Apply the convolution filter to the whole page
                    page.Filter(page.Bounds, filterOptions);

                    // Output path for the current page
                    string outputPath = $@"C:\Images\output_page_{i + 1}.png";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed page
                    var saveOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    page.Save(outputPath, saveOptions);
                }
            }
        }
    }
}