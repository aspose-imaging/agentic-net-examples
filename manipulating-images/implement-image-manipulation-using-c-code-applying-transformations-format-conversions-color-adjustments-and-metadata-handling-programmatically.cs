using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // -------------------------------------------------
        // Load an existing JPEG image and apply transformations
        // -------------------------------------------------
        using (Image image = Image.Load("input.jpg"))
        {
            // Adjust brightness and contrast (specific to JPEG images)
            if (image is JpegImage jpeg)
            {
                jpeg.AdjustBrightness(30);          // increase brightness
                jpeg.AdjustContrast(1.2f);          // increase contrast
            }

            // Rotate the image 45 degrees around its centre
            image.Rotate(45);

            // Resize to 800x600 using a high‑quality resampling filter
            var resizeSettings = new ImageResizeSettings
            {
                Mode = ResizeType.CubicBSpline,
                FilterType = ImageFilterType.Lanczos
            };
            image.Resize(800, 600, resizeSettings);

            // Convert the image to grayscale
            image.Grayscale();

            // Replace pure red with blue, allowing a tolerance of 10
            image.ReplaceColor(Color.Red, 10, Color.Blue);

            // Remove all metadata (EXIF, XMP, etc.)
            image.RemoveMetadata();

            // Save the processed image as PNG using default PNG options
            var pngOptions = new PngOptions();
            image.Save("output.png", pngOptions);
        }

        // -------------------------------------------------
        // Create a new blank BMP image, set background, and save
        // -------------------------------------------------
        var bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            // Define the file where the new image will be created
            Source = new Aspose.Imaging.Sources.FileCreateSource("blank.bmp", false)
        };

        // Create a 500x500 BMP image using the specified options
        using (Image blank = Image.Create(bmpOptions, 500, 500))
        {
            // Set a light‑gray background color
            blank.BackgroundColor = Color.LightGray;
            blank.HasBackgroundColor = true;

            // Save the newly created image to the file defined in FileCreateSource
            blank.Save();
        }
    }
}