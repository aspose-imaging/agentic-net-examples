// HOW-TO: How To Load And Save A PNG Image Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to read a PNG file, manipulate its pixels, and then write the modified image back to disk using Aspose.Imaging in a C# application.
 * 2. When your .NET service must validate that a PNG image can be opened and saved without corruption before further processing.
 * 3. When you want to convert a PNG stored in a custom location to a new file path while preserving image quality using Aspose.Imaging’s RasterImage class.
 * 4. When an automated batch job has to load multiple PNG files, apply transformations, and save each result with specific PNG options in C#.
 * 5. When you are building a web API that receives a PNG upload, needs to re‑encode it with Aspose.Imaging, and returns the saved file to the client.
 */
