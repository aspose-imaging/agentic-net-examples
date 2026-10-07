// HOW-TO: Detect Transparency in PNG Converted from TIFF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/source.tif";
            string outputPath = "Output/result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                tiffImage.Save(outputPath, pngOptions);
            }

            using (RasterImage pngImage = (RasterImage)Image.Load(outputPath))
            {
                int[] pixels = pngImage.LoadArgb32Pixels(pngImage.Bounds);
                bool hasTransparency = pixels.Any(p => ((p >> 24) & 0xFF) < 255);
                Console.WriteLine(hasTransparency
                    ? "Image has transparency."
                    : "Image is fully opaque.");
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
 * 1. When you need to verify whether a PNG created from a multi‑page TIFF contains any transparent pixels before publishing it on a website.
 * 2. When automating a batch conversion pipeline and you must log images that lose or gain alpha channel information during TIFF‑to‑PNG conversion.
 * 3. When generating thumbnails for a digital asset management system and you need to flag images that require a solid background because they are not fully opaque.
 * 4. When preparing print‑ready files and you must ensure that converted PNGs do not contain unintended transparency that could affect color separations.
 * 5. When debugging an image processing workflow and you want to quickly output the transparency status of a PNG after applying Aspose.Imaging conversion settings.
 */
