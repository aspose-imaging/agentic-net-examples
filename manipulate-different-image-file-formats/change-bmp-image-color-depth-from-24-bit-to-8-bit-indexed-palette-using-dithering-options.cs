// HOW-TO: Convert 24‑Bit BMP to 8‑Bit Indexed BMP With Dithering In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output/output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                BmpOptions saveOptions = new BmpOptions();
                saveOptions.BitsPerPixel = 8;

                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce the file size of a high‑color BMP for use in legacy applications that only support 8‑bit indexed images.
 * 2. When preparing BMP assets for embedded systems or game consoles that require a limited color palette and dithering to preserve visual quality.
 * 3. When converting scanned photographs to a smaller palette for faster loading in web pages while maintaining acceptable detail.
 * 4. When automating batch processing of BMP files to meet a specific graphics pipeline that expects 8‑bit indexed BMPs with Floyd‑Steinberg dithering.
 * 5. When integrating Aspose.Imaging into a C# service that must transform user‑uploaded 24‑bit BMPs into 8‑bit indexed versions for storage optimization.
 */
