using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Save the image (no filter applied due to namespace restrictions)
                raster.Save(outputPath);

                // Verify that all pixel components are within the 0‑255 range
                for (int y = 0; y < raster.Height; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        int argb = raster.GetArgb32Pixel(x, y);
                        int a = (argb >> 24) & 0xFF;
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;

                        if (a < 0 || a > 255 ||
                            r < 0 || r > 255 ||
                            g < 0 || g > 255 ||
                            b < 0 || b > 255)
                        {
                            Console.Error.WriteLine($"Pixel out of range at ({x},{y}): A={a}, R={r}, G={g}, B={b}");
                            return;
                        }
                    }
                }

                Console.WriteLine("All pixel values are clamped between 0 and 255.");
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
 * 1. When writing a C# unit test for a custom Aspose.Imaging filter to verify that all ARGB pixel components are correctly clamped between 0 and 255 after processing.
 * 2. When validating an image conversion pipeline that loads a PNG with Aspose.Imaging, saves it, and must ensure no out‑of‑range color values are introduced.
 * 3. When building a web API that accepts user‑uploaded PNG files, processes them with Aspose.Imaging, and needs to confirm the raster image’s pixel values are safe before further analysis.
 * 4. When performing batch image processing on a directory of PNG files in a .NET application and want to detect any corrupted pixels that fall outside the 0‑255 range.
 * 5. When debugging a desktop C# application that renders PNG images using Aspose.Imaging and you need to confirm that the loaded raster image contains only valid ARGB values.
 */