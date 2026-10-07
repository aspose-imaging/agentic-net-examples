// HOW-TO: Invert Colors of EPS and Save as High Quality JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output\\inverted.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    epsImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (var raster = (RasterImage)Image.Load(memoryStream))
                    {
                        var bounds = raster.Bounds;
                        int[] pixels = raster.LoadArgb32Pixels(bounds);
                        for (int i = 0; i < pixels.Length; i++)
                        {
                            int argb = pixels[i];
                            int a = (argb >> 24) & 0xFF;
                            int r = (argb >> 16) & 0xFF;
                            int g = (argb >> 8) & 0xFF;
                            int b = argb & 0xFF;

                            r = 255 - r;
                            g = 255 - g;
                            b = 255 - b;

                            pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                        }
                        raster.SaveArgb32Pixels(bounds, pixels);

                        var jpegOptions = new JpegOptions { Quality = 100 };
                        raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate a negative version of a vector logo stored as EPS for printing proofs, you can invert its colors and export a high‑quality JPEG.
 * 2. When a web application must display a preview of an EPS illustration with opposite colors for a dark‑mode theme, this code converts and saves the result as a JPEG.
 * 3. When an automated workflow requires batch processing of EPS files to create high‑resolution JPEG thumbnails with inverted colors for visual testing, the snippet provides the needed steps.
 * 4. When a digital asset management system needs to store a color‑inverted JPEG version of an EPS artwork for archival or comparison purposes, this approach handles the conversion.
 * 5. When a marketing tool wants to apply a quick negative‑effect filter to EPS graphics before embedding them in email campaigns, the code produces a quality JPEG ready for distribution.
 */
