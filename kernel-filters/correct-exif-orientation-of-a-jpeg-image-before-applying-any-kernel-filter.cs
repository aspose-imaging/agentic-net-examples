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
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Correct orientation based on EXIF data
                image.AutoRotate();

                // Apply a sharpen filter
                image.Filter(image.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image as JPEG
                JpegOptions jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When a web application receives user‑uploaded JPEG photos that may have been taken on phones with different orientations, a developer can use this code to auto‑rotate the images based on EXIF data before applying a sharpen filter and saving them for display.
 * 2. When building a batch image‑processing tool that prepares product photos for an e‑commerce catalog, a developer can run this code to correct the orientation of each JPEG, enhance details with a sharpen filter, and output optimized JPEG files.
 * 3. When integrating an automated photo‑enhancement pipeline into a digital asset management system, a developer can employ this code to ensure all stored JPEGs have the correct orientation before applying kernel‑based filters such as sharpening.
 * 4. When creating a desktop utility that fixes rotated screenshots taken on mobile devices and improves their clarity, a developer can use this C# example to auto‑rotate the JPEG, apply a sharpen filter, and save the result.
 * 5. When developing a server‑side image service that generates thumbnails from user‑submitted JPEGs, a developer can first correct EXIF orientation with AutoRotate, sharpen the image for better visual quality, and then save the processed JPEG for further resizing.
 */