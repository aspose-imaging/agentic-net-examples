using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to highlight the outlines of objects in a PNG photograph for a computer‑vision preprocessing step, they can apply the custom edge‑detection kernel using Aspose.Imaging’s ConvolutionFilter in C#.
 * 2. When building a web service that generates printable line‑art versions of user‑uploaded PNG graphics, the code can be used to convert the image to a high‑contrast edge map before saving the result.
 * 3. When creating an automated quality‑control pipeline that flags blurry product images, the edge‑detection filter helps measure edge strength in PNG files by processing them with Aspose.Imaging’s raster filter options.
 * 4. When integrating a desktop application that visualizes architectural floor plans as sharp outlines, developers can run this C# snippet to apply a Laplacian kernel to PNG scans and store the enhanced output.
 * 5. When developing a batch‑processing tool that prepares PNG assets for OCR by emphasizing edges, the ConvolutionFilterOptions with a custom kernel can be applied to each raster image before feeding it to the OCR engine.
 */