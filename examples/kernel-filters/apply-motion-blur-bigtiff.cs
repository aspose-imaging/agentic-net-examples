using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class MotionBlurBigTiffExample
{
    static void Main()
    {
        // Input image path (any supported format)
        string inputPath = @"C:\Temp\sample.png";

        // Output path – the file will be saved as a BigTIFF
        string outputPath = @"C:\Temp\sample_motionblur.bigtiff";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access its frames
            TiffImage tiffImage = (TiffImage)image;

            // Create a BigTiffImage from the existing frames
            // This ensures the resulting file is saved in the BigTIFF format
            BigTiffImage bigTiff = new BigTiffImage(tiffImage.Frames);

            // Apply a motion blur (motion Wiener) filter to the whole image
            // Parameters: length = 10, smooth = 1.0, angle = 90 degrees
            bigTiff.Filter(
                bigTiff.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image as BigTIFF
            bigTiff.Save(outputPath);

            // Dispose the BigTiffImage explicitly (optional, as using would handle it)
            bigTiff.Dispose();
        }
    }
}