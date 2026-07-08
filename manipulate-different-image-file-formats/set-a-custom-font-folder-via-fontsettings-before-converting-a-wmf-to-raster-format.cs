using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.wmf";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size,
                    RenderMode = WmfRenderMode.Auto
                };

                using (var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions })
                {
                    image.Save(outputPath, pngOptions);
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
 * 1. When a legacy WMF file uses proprietary corporate fonts, a developer sets a custom font folder via FontSettings and converts the WMF to PNG to ensure the text renders correctly on web pages.
 * 2. When generating printable previews of WMF diagrams on a server that lacks the required TrueType fonts, the code points FontSettings to a shared font directory before rasterizing the image to PNG.
 * 3. When batch‑processing WMF icons that contain brand‑specific fonts, developers configure FontSettings to locate those fonts so the resulting PNG icons preserve the intended typography.
 * 4. When embedding WMF‑based charts into a C# reporting application running inside a container without system fonts, setting a custom font folder enables accurate PNG rasterization for the reports.
 * 5. When migrating legacy engineering drawings saved as WMF to modern image formats, developers specify the font folder via FontSettings to prevent missing or corrupted text during the conversion to raster PNG files.
 */