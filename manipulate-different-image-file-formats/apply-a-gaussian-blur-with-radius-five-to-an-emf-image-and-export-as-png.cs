// HOW-TO: Apply Gaussian Blur to EMF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image emfImage = Image.Load(inputPath))
            {
                int width = emfImage.Width;
                int height = emfImage.Height;

                using (RasterImage raster = (RasterImage)Image.Create(new PngOptions(), width, height))
                {
                    Graphics graphics = new Graphics(raster);
                    graphics.DrawImage(emfImage, new Rectangle(0, 0, width, height));

                    var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions
                    {
                        Radius = 5
                    };
                    raster.Filter(raster.Bounds, blurOptions);

                    raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to soften vector graphics from an EMF file before embedding them in a web page as a PNG.
 * 2. When a developer wants to create a blurred thumbnail of a Windows Metafile for a document preview.
 * 3. When a developer must preprocess EMF logos with a radius‑5 Gaussian blur to meet branding guidelines before converting to PNG.
 * 4. When a developer is building a batch conversion tool that applies a consistent blur effect to multiple EMF assets and outputs PNG files.
 * 5. When a developer needs to render an EMF diagram, apply a blur filter, and store the result as a lossless PNG for archival or reporting purposes.
 */
