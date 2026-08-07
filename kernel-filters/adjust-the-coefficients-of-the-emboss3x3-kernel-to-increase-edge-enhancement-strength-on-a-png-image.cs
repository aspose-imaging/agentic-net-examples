using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

                double[,] baseKernel = ConvolutionFilter.Emboss3x3;
                double factor = 2.0;
                int rows = baseKernel.GetLength(0);
                int cols = baseKernel.GetLength(1);
                double[,] enhancedKernel = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        enhancedKernel[i, j] = baseKernel[i, j] * factor;
                    }
                }

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(enhancedKernel));

                PngOptions saveOptions = new PngOptions();
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
 * 1. When a developer wants to sharpen the details of product photos in PNG format before uploading them to an e‑commerce site, they can increase the emboss kernel coefficients to boost edge enhancement using Aspose.Imaging’s ConvolutionFilter in C#.
 * 2. When preparing PNG assets for a mobile game’s UI, a developer may apply a stronger emboss filter to highlight textures and make UI elements stand out on high‑resolution screens.
 * 3. When converting scanned engineering drawings stored as PNG files into clearer visualizations, a developer can amplify the emboss 3x3 kernel to emphasize line edges and improve readability.
 * 4. When generating stylized thumbnails for a photo‑gallery website, a developer can use the enhanced emboss kernel to add a pronounced edge‑detect effect that makes the thumbnails more eye‑catching.
 * 5. When processing PNG screenshots for a documentation pipeline, a developer may apply a boosted emboss convolution filter to accentuate UI borders and improve contrast for printed manuals.
 */