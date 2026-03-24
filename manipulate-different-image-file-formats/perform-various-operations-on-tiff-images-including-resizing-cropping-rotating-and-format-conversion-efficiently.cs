using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input TIFF file
        string inputPath = "input\\sample.tif";

        // Output files
        string resizedPath = "output\\resized.tif";
        string croppedPath = "output\\cropped.tif";
        string rotatedPath = "output\\rotated.tif";
        string jpegPath = "output\\converted.jpg";

        // Verify input exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(resizedPath));
        Directory.CreateDirectory(Path.GetDirectoryName(croppedPath));
        Directory.CreateDirectory(Path.GetDirectoryName(rotatedPath));
        Directory.CreateDirectory(Path.GetDirectoryName(jpegPath));

        // ---------- Resize ----------
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Resize to 200x200 using nearest neighbour
            image.Resize(200, 200, ResizeType.NearestNeighbourResample);

            // Save resized TIFF
            var resizeOptions = new TiffOptions(TiffExpectedFormat.Default);
            image.Save(resizedPath, resizeOptions);
        }

        // ---------- Crop ----------
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Define crop rectangle (e.g., top-left 100x100)
            var cropRect = new Rectangle(0, 0, 100, 100);
            image.Crop(cropRect);

            // Save cropped TIFF
            var cropOptions = new TiffOptions(TiffExpectedFormat.Default);
            image.Save(croppedPath, cropOptions);
        }

        // ---------- Rotate ----------
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise, expand canvas, white background
            image.Rotate(90f, true, Color.White);

            // Save rotated TIFF
            var rotateOptions = new TiffOptions(TiffExpectedFormat.Default);
            image.Save(rotatedPath, rotateOptions);
        }

        // ---------- Convert to JPEG ----------
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            var jpegOptions = new JpegOptions();
            image.Save(jpegPath, jpegOptions);
        }
    }
}