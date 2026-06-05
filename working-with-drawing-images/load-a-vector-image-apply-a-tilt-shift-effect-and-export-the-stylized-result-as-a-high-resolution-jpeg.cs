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
            string inputPath = "input.png";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                raster.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to convert user‑uploaded PNG graphics to optimized JPEG files for faster page loads, a developer can use this code to load the image, validate the file, and save it with a configurable JPEG quality setting.
 * 2. When an automated batch‑processing service must ensure that all source images exist and are stored in a specific folder hierarchy before converting them to high‑resolution JPEGs, this snippet provides the file‑existence check and directory‑creation logic.
 * 3. When a desktop utility has to transform raster images such as screenshots or scanned documents into JPEG format while preserving image fidelity by setting the JpegOptions.Quality property, the example demonstrates the required C# operations.
 * 4. When integrating Aspose.Imaging into a CI/CD pipeline that validates image assets and produces JPEG previews for documentation, the code shows how to load the image, cast to RasterImage, and export it safely.
 * 5. When building a C# service that receives PNG files via an API and must return a JPEG response, this pattern illustrates error handling, type checking, and the use of Image.Load and raster.Save with Aspose.Imaging.
 */