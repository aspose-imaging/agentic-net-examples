// HOW-TO: Apply Gaussian Blur To PSD And Save As PNG Using C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/input.psd";
            string outputPath = "output/output.png";

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

                // Apply Gaussian blur
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Prepare PNG export options
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the blurred image as PNG
                raster.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to generate a softened preview of a Photoshop PSD file for faster loading, developers can use this code to blur the image and export it as a lightweight PNG.
 * 2. When an e‑commerce platform wants to create background‑blurred product thumbnails from original PSD assets, the snippet provides a simple way to apply a Gaussian blur and save the result in PNG format.
 * 3. When a digital publishing workflow requires converting high‑resolution PSD artwork into PNG with a subtle blur for watermarking or visual effect, this code automates the process in C#.
 * 4. When a desktop utility must batch‑process PSD files to produce blurred PNG versions for UI placeholders, developers can integrate the Aspose.Imaging filter and save steps shown here.
 * 5. When a mobile app backend needs to serve blurred versions of user‑uploaded PSD designs to protect intellectual property while still displaying a preview, this example demonstrates how to apply the blur and output a PNG using C#.
 */
