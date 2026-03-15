using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class ImageProcessingExample
{
    static void Main()
    {
        // Directory containing the source image and where output files will be written
        string dir = @"C:\temp\";

        // Load the source image (BMP in this example)
        using (Image image = Image.Load(Path.Combine(dir, "sample.bmp")))
        {
            // Apply a rotation transformation (90 degrees clockwise)
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // -------------------------------------------------
            // Save the transformed image as JPEG with moderate compression
            // -------------------------------------------------
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 75 // Adjust quality to balance size and visual fidelity
            };
            image.Save(Path.Combine(dir, "output_quality75.jpg"), jpegOptions);

            // -------------------------------------------------
            // Save the same image as PNG (lossless format)
            // -------------------------------------------------
            PngOptions pngOptions = new PngOptions(); // Default PNG options are lossless
            image.Save(Path.Combine(dir, "output.png"), pngOptions);

            // -------------------------------------------------
            // Save the image as a 1‑bit monochrome BMP
            // -------------------------------------------------
            // Convert the image to black‑white using Otsu binarization
            BmpImage bmpImage = (BmpImage)image;
            bmpImage.BinarizeOtsu();

            BmpOptions bmpOptions = new BmpOptions
            {
                // Use a palette that contains only black and white
                Palette = ColorPaletteHelper.CreateMonochrome(),
                // Allocate only 1 bit per pixel for monochrome data
                BitsPerPixel = 1
            };
            image.Save(Path.Combine(dir, "output_monochrome.bmp"), bmpOptions);
        }
    }
}