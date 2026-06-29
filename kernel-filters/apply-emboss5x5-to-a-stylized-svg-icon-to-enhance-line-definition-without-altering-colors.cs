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
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Filter(
                            raster.Bounds,
                            new ConvolutionFilterOptions(
                                ConvolutionFilter.Emboss5x5));

                        raster.Save(outputPath, new PngOptions());
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a vector‑based SVG logo into a high‑resolution PNG thumbnail while sharpening the icon’s lines with an emboss filter, they can use this code.
 * 2. When a web application must display crisp, stylized SVG icons on low‑resolution devices and wants to enhance edge definition without changing the original colors, the Emboss5x5 filter applied via Aspose.Imaging is ideal.
 * 3. When an e‑learning platform generates printable PNG assets from SVG diagrams and requires subtle line emphasis for better readability, this C# routine rasterizes the SVG and applies a 5×5 emboss convolution.
 * 4. When a UI designer exports SVG UI elements to PNG for inclusion in a Windows Forms app and wants to add a tactile embossed effect to improve visual hierarchy, the code demonstrates the necessary steps.
 * 5. When an automated build pipeline processes SVG assets into PNG sprites and needs to ensure consistent line sharpness across all icons, the Emboss5x5 convolution filter can be integrated as shown.
 */