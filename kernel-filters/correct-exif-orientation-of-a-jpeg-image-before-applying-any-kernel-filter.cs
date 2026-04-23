using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Correct orientation based on EXIF data
                image.AutoRotate();

                // Apply a sharpen filter to the entire image
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image with JPEG options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}