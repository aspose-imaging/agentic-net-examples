using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Ensure we are working with a JPEG image
                JpegImage jpegImage = (JpegImage)image;

                // Correct orientation based on EXIF data
                jpegImage.AutoRotate();

                // Apply a sharpen filter as an example kernel filter
                RasterImage raster = (RasterImage)jpegImage;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the processed image
                jpegImage.Save(outputPath);
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
 * 1. When a web application receives user‑uploaded JPEG photos that may have been taken in portrait mode, a developer can use this code to auto‑rotate the images based on EXIF orientation before sharpening them for display.
 * 2. When building a batch‑processing tool that prepares product catalog images, the code ensures each JPEG is correctly oriented and then applies a sharpen kernel filter to enhance visual detail.
 * 3. When integrating a photo‑editing feature into a mobile‑to‑desktop sync service, developers can run this routine to fix EXIF rotation and improve image clarity with a sharpen filter before saving the files.
 * 4. When generating thumbnails for a digital asset management system, the code can correct the JPEG orientation and apply a custom kernel filter to produce consistently upright and crisp preview images.
 * 5. When automating the preparation of scanned documents saved as JPEGs, a developer can employ this snippet to auto‑rotate based on EXIF data and sharpen the pages for better OCR accuracy.
 */