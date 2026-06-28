using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Resize to half of original dimensions
                image.Resize(image.Width / 2, image.Height / 2);

                // Apply Emboss3x3 filter
                RasterImage raster = (RasterImage)image;
                var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the result as PNG
                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to generate smaller, stylized thumbnails of user‑uploaded PNG photos, a developer can use this C# code with Aspose.Imaging to resize the image to half size and apply the Emboss3x3 convolution filter before saving.
 * 2. When an e‑commerce platform wants to display product images with a subtle embossed effect while reducing bandwidth, a developer can employ the Aspose.Imaging Resize and Emboss3x3 filter on PNG files in a .NET service.
 * 3. When a desktop utility creates printable PNG assets with a vintage embossed look, a C# developer can call this code to shrink the original image and apply the Emboss3x3 filter in one pass.
 * 4. When an automated batch‑processing script must prepare PNG graphics for mobile devices by halving their dimensions and adding a depth‑enhancing emboss effect, the Aspose.Imaging filter pipeline shown can be integrated into the .NET workflow.
 * 5. When a content management system needs to store optimized PNG images that are both smaller and visually enhanced with a 3×3 emboss convolution, a developer can implement this code to resize and filter the images on upload.
 */