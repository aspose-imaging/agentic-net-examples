// HOW-TO: Apply Horizontal Edge Detection to SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        try
        {
            // Hardcoded paths
            string inputPath = "input.svg";
            string tempPngPath = "temp\\temp.png";
            string outputPath = "output\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG, apply horizontal edge detection, and save the result
            using (Image img = Image.Load(tempPngPath))
            {
                var rasterImage = (RasterImage)img;

                // Custom kernel emphasizing horizontal edges
                double[,] kernel = new double[,]
                {
                    { -1, -2, -1 },
                    {  0,  0,  0 },
                    {  1,  2,  1 }
                };

                var convOptions = new ConvolutionFilterOptions(kernel);
                rasterImage.Filter(rasterImage.Bounds, convOptions);
                rasterImage.Save(outputPath);
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When you need to highlight structural lines in an architectural SVG by converting it to PNG and applying a horizontal edge‑detecting convolution filter in C#.
 * 2. When you want to preprocess vector floor plans for edge‑based analysis or feature extraction by rasterizing them and emphasizing horizontal edges.
 * 3. When creating stylized blueprint visuals that accentuate horizontal walls and beams using Aspose.Imaging’s custom kernel in a .NET application.
 * 4. When preparing SVG drawings for OCR or machine‑learning pipelines that require clear horizontal edge contrast after rasterization.
 * 5. When automating a batch workflow that converts SVG diagrams to high‑contrast PNGs with horizontal edge emphasis for printing or web display.
 */
