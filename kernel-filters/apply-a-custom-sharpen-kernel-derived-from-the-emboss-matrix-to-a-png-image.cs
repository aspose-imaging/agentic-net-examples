using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var kernel = ConvolutionFilter.Emboss3x3;
                var options = new ConvolutionFilterOptions(kernel);

                raster.Filter(raster.Bounds, options);
                raster.Save(outputPath);
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
 * 1. When a developer needs to enhance the visual contrast of a PNG product photo before uploading it to an e‑commerce site, they can apply the custom sharpen kernel derived from the emboss matrix to make details pop.
 * 2. When preparing PNG screenshots for a user manual, a developer can use this code to sharpen edges and improve readability of UI elements.
 * 3. When processing scanned PNG documents for archival, applying the emboss‑based sharpen filter helps highlight text and line art without introducing excessive noise.
 * 4. When generating stylized thumbnail previews of PNG images for a gallery, a developer can run the custom convolution to add a subtle embossed sharpening effect that draws viewer attention.
 * 5. When preprocessing PNG images for a computer‑vision pipeline, a developer can sharpen subtle features with the emboss‑derived kernel to improve feature detection accuracy.
 */