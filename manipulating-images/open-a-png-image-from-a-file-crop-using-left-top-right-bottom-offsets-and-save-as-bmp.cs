// HOW-TO: Crop PNG Image With Offsets And Save As BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                if (!rasterImage.IsCached)
                {
                    rasterImage.CacheData();
                }

                int left = 10;
                int top = 10;
                int right = 10;
                int bottom = 10;

                rasterImage.Crop(left, right, top, bottom);
                rasterImage.Save(outputPath, new BmpOptions());
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
 * 1. When you need to remove a uniform border from scanned PNG screenshots and store the trimmed result as a BMP for legacy Windows applications.
 * 2. When generating thumbnails for a game asset pipeline that requires BMP format and you must crop a fixed number of pixels from each side of the original PNG.
 * 3. When processing medical imaging data where the PNG files contain extra padding and the analysis software only accepts BMP files, so you crop and convert them programmatically.
 * 4. When automating batch preparation of icons for embedded devices that only support BMP, and you need to consistently trim 10‑pixel margins from each side of the source PNG.
 * 5. When integrating Aspose.Imaging into a C# service that receives user‑uploaded PNGs, removes unwanted edges, and saves the cleaned image as BMP for downstream processing.
 */
