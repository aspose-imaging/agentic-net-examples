using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\sample_blur.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access the Filter method
            TiffImage tiffImage = (TiffImage)image;

            // Apply a motion blur (using MotionWienerFilterOptions as the closest available option)
            // Length = 10, Smooth = 1.0, Angle = 45 degrees
            var motionOptions = new MotionWienerFilterOptions(10, 1.0, 45.0);
            tiffImage.Filter(tiffImage.Bounds, motionOptions);

            // Save the result as JPEG
            var jpegOptions = new JpegOptions();
            tiffImage.Save(outputPath, jpegOptions);
        }
    }
}