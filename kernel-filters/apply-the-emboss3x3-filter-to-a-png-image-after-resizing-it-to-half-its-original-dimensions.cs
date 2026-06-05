using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Resize to half of the original dimensions
                raster.Resize(raster.Width / 2, raster.Height / 2);

                // Apply Emboss3x3 filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save the processed image as PNG
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
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
 * 1. When a developer needs to generate a smaller, stylized thumbnail of a PNG photo for a web gallery, they can resize the image to half its size and apply an Emboss3x3 filter using Aspose.Imaging for .NET.
 * 2. When creating printable product mock‑ups, a developer may shrink high‑resolution PNG assets and add an emboss effect to simulate a raised‑surface look before saving the result.
 * 3. When optimizing PNG icons for a mobile app, a developer can reduce the dimensions by 50 % and apply the Emboss3x3 convolution filter to give the icons a subtle 3‑D appearance without external tools.
 * 4. When processing user‑uploaded PNG screenshots for a documentation portal, a developer can automatically resize them to half their original width and height and emboss them to improve visual contrast.
 * 5. When building an automated batch job that prepares PNG images for an e‑commerce catalog, a developer can use C# and Aspose.Imaging to resize each image to half size and apply the Emboss3x3 filter to create a consistent, artistic look.
 */