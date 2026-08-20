// HOW-TO: Apply Gaussian Blur and Edge Detection to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputSvgPath = "input.svg";
        string intermediatePngPath = "temp.png";
        string outputPngPath = "output.png";

        try
        {
            // Verify input SVG exists
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(intermediatePngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));

            // Rasterize SVG to PNG (intermediate file)
            using (var svgImage = new SvgImage(inputSvgPath))
            {
                var rasterizationOptions = new SvgRasterizationOptions();
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterizationOptions };
                svgImage.Save(intermediatePngPath, pngOptions);
            }

            // Load the rasterized PNG as a RasterImage
            using (Image image = Image.Load(intermediatePngPath))
            {
                var rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply custom edge‑detection kernel (using the built‑in Emboss3x3 kernel as an example)
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save the final image
                rasterImage.Save(outputPngPath);
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
 * 1. When you need to soften an SVG illustration and then highlight its outlines for a web thumbnail, you can rasterize the SVG to PNG, apply a Gaussian blur, and run an emboss edge‑detection filter using Aspose.Imaging in C#.
 * 2. When generating print‑ready assets that require a subtle blur followed by a stylized edge effect, this code converts the vector SVG to a raster image, applies the blur and custom convolution, and saves the result as PNG.
 * 3. When creating a preprocessing pipeline for computer‑vision models that expects blurred and edge‑enhanced PNG inputs derived from SVG sources, the example shows how to automate the conversion and filtering in .NET.
 * 4. When building an image‑editing feature in a desktop application that lets users apply a blur then an emboss effect to uploaded SVG files, the snippet demonstrates the required Aspose.Imaging calls.
 * 5. When preparing SVG graphics for UI icons that need a softened background and a highlighted border, this code shows how to rasterize, blur, apply a convolution kernel, and output a PNG using C#.
 */
