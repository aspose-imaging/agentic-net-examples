// HOW-TO: Set Image DPI to 300 and Save as PSD in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.HorizontalResolution = 300;
                raster.VerticalResolution = 300;

                PsdOptions options = new PsdOptions();
                options.Source = new FileCreateSource(outputPath, false);

                image.Save(outputPath, options);
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
 * 1. When you need to convert a JPEG to a Photoshop PSD file while increasing the DPI to 300 for high‑resolution printing.
 * 2. When preparing images for a print‑ready PDF workflow and must ensure the source raster has 300 dpi before saving as PSD.
 * 3. When a graphics application requires consistent horizontal and vertical resolution across layers, and you use Aspose.Imaging to set both to 300 dpi.
 * 4. When automating batch processing of photos to meet publishing standards that demand 300 dpi PSD files generated from JPEGs.
 * 5. When integrating image conversion into a C# service that must preserve image quality by adjusting resolution before exporting to PSD format.
 */
