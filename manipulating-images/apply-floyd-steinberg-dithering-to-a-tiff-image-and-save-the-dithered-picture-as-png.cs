// HOW-TO: Apply Floyd Steinberg Dithering to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                tiff.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                tiff.Save(outputPath, pngOptions);
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
 * 1. When you need to reduce the color depth of a high‑resolution TIFF for web display while preserving visual detail, you can dither it and output a PNG.
 * 2. When converting scanned documents from TIFF to PNG for inclusion in a PDF, applying Floyd‑Steinberg dithering prevents banding in grayscale images.
 * 3. When generating thumbnails of large TIFF photos for a mobile app, dithering creates a smaller PNG with acceptable quality and faster load times.
 * 4. When preparing archival TIFF artwork for a game engine that only accepts PNG textures, Floyd‑Steinberg dithering maintains the original shading after color reduction.
 * 5. When automating batch processing of TIFF maps to PNG for GIS applications, dithering ensures the reduced‑palette images remain legible after conversion.
 */
