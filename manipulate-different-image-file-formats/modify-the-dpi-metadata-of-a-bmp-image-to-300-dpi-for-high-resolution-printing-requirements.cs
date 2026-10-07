// HOW-TO: Set BMP Image DPI to 300 for High Resolution Printing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output/output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    raster.HorizontalResolution = 300;
                    raster.VerticalResolution = 300;
                    raster.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
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
 * 1. When preparing BMP graphics for a brochure, a developer must increase the image DPI to 300 to meet print quality standards.
 * 2. When converting scanned documents saved as BMP files, setting the horizontal and vertical resolution ensures they appear sharp on laser printers.
 * 3. When integrating a legacy BMP asset into a .NET reporting tool, adjusting its DPI metadata prevents pixelation in the generated PDF.
 * 4. When automating a batch process that uploads BMP images to a print‑on‑demand service, the code guarantees each file meets the required 300 DPI specification.
 * 5. When troubleshooting low‑resolution output from a CAD export saved as BMP, a developer can use this snippet to correct the DPI without altering the pixel data.
 */
