using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
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
 * 1. When a developer needs to convert user‑uploaded JPEG photos to lossless PNG files for web display while ensuring the output folder exists.
 * 2. When an automated batch job must verify that a source image file exists before loading it as a RasterImage in C# using Aspose.Imaging.
 * 3. When a .NET application has to catch and log image‑processing errors such as unsupported formats or I/O failures during conversion.
 * 4. When a service has to create a PNG thumbnail from a JPEG source by loading the image, casting to RasterImage, and saving with PngOptions.
 * 5. When a build script must programmatically create the target directory structure before writing the converted PNG to avoid runtime exceptions.
 */