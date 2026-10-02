// HOW-TO: Apply Motion Blur and Sharpen to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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

            using (var sourceImage = Image.Load(inputPath))
            {
                RasterImage rasterImage = null;
                string tempPath = null;

                if (sourceImage is RasterImage ri)
                {
                    rasterImage = ri;
                }
                else if (sourceImage is VectorImage vi)
                {
                    tempPath = Path.Combine(Path.GetDirectoryName(outputPath) ?? "", "temp_raster.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
                    vi.Save(tempPath, new PngOptions());
                    rasterImage = (RasterImage)Image.Load(tempPath);
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image type.");
                    return;
                }

                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(2, 0)));

                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3));

                rasterImage.Save(outputPath, new PngOptions());

                if (tempPath != null)
                {
                    rasterImage.Dispose();
                    try { File.Delete(tempPath); } catch { }
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
 * 1. When you need to convert an SVG illustration to a high‑quality PNG while adding a subtle motion‑blur effect followed by sharpening to enhance edge definition.
 * 2. When preparing graphics for web thumbnails that require a consistent blur‑then‑sharpen filter chain to improve visual appeal without manual editing.
 * 3. When automating batch processing of vector assets for a game UI, applying motion blur to simulate movement and then sharpening to retain crisp details before saving as PNG.
 * 4. When integrating image preprocessing into a C# reporting tool that receives SVG charts, adds a motion‑blur filter to soften lines, sharpens them, and outputs PNG for PDF embedding.
 * 5. When building a server‑side service that rasterizes uploaded SVG logos, applies a 2‑pixel motion blur and a 3×3 sharpen filter to meet brand style guidelines, and returns the result as a PNG file.
 */
