// HOW-TO: Restore Details of a Blurred SVG Using Deconvolution Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
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
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Input file is not a valid SVG image.");
                    return;
                }

                string tempPngPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");

                PngOptions pngOptions = new PngOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageWidth = svgImage.Width;
                rasterOptions.PageHeight = svgImage.Height;
                pngOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(tempPngPath, pngOptions);

                using (RasterImage rasterImage = (RasterImage)Image.Load(tempPngPath))
                {
                    int size = 3;
                    double sigma = 1.0;
                    DeconvolutionFilterOptions deconvOptions = new DeconvolutionFilterOptions(ConvolutionFilter.GetGaussian(size, sigma));
                    rasterImage.Filter(rasterImage.Bounds, deconvOptions);
                    rasterImage.Save(outputPath);
                }

                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When you need to sharpen a blurry SVG logo before embedding it in a PDF, you can rasterize the SVG and apply a deconvolution filter with Aspose.Imaging in C#.
 * 2. When a web application must convert user‑uploaded SVG diagrams to high‑quality PNG thumbnails while restoring lost details, this code provides an automated solution.
 * 3. When a batch process has to improve the readability of scanned vector graphics that were saved as SVGs with motion blur, the deconvolution filter can recover edges programmatically.
 * 4. When generating print‑ready assets from SVG artwork, you may need to enhance fine lines after rasterization to meet DPI requirements, using Aspose’s Gaussian deconvolution in C#.
 * 5. When a digital asset management system requires restoring clarity to blurred SVG icons before storing them as PNGs, this approach applies a convolution‑based deconvolution filter automatically.
 */
