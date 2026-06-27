using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

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

                double[,] baseKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;

                int rows = baseKernel.GetLength(0);
                int cols = baseKernel.GetLength(1);
                double[,] enhancedKernel = new double[rows, cols];
                double strengthFactor = 2.0;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        enhancedKernel[i, j] = baseKernel[i, j] * strengthFactor;
                    }
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(enhancedKernel);
                raster.Filter(raster.Bounds, filterOptions);

                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to boost the edge‑enhancement of a PNG graphic for a web UI, they can multiply the Aspose.Imaging Emboss3x3 kernel coefficients to create a stronger emboss effect before saving the image.
 * 2. When preparing product photos for an e‑commerce catalog, a developer may apply a heightened emboss filter using C# and Aspose.Imaging to make product outlines more pronounced in the final PNG files.
 * 3. When generating stylized map tiles, a GIS programmer can increase the strength of the Emboss3x3 convolution kernel to accentuate terrain edges in PNG tiles for better visual contrast.
 * 4. When creating printable marketing materials, a designer‑developer can use the code to intensify the emboss filter on PNG logos, ensuring the edges stand out after high‑resolution printing.
 * 5. When building an image‑processing pipeline that detects structural details, a developer may adjust the Emboss3x3 kernel coefficients in C# with Aspose.Imaging to amplify edge detection before further analysis of PNG images.
 */