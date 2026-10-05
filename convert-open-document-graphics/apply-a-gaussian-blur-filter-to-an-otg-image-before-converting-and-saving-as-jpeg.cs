// HOW-TO: Apply Gaussian Blur to OTG Image and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.otg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
                    return;
                }

                var blurOptions = new GaussianBlurFilterOptions();

                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var jpegOptions = new JpegOptions();
                rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to soften the details of a high‑resolution OTG graphic before delivering it as a smaller JPEG for web preview.
 * 2. When you want to reduce noise in scanned OTG documents by applying a Gaussian blur and then store them as JPEG files for archival.
 * 3. When an application must automatically preprocess OTG icons with a blur effect to create consistent thumbnail JPEGs for a mobile app.
 * 4. When you are building a batch conversion tool that applies a Gaussian blur to each OTG image to meet a client’s visual style guidelines before saving as JPEG.
 * 5. When you need to integrate image filtering into a C# service that receives OTG files, blurs them for privacy, and returns JPEGs to end users.
 */
