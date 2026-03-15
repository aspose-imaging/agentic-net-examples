using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input vector image path (supports SVG, EMF, WMF, CDR, CMX, etc.)
        string inputFilePath = @"C:\Images\input.svg";
        // Output PNG path with transparent background
        string outputFilePath = @"C:\Images\output.png";

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputFilePath))
        {
            // Cast to VectorImage to access vector-specific methods
            VectorImage vectorImage = image as VectorImage;
            if (vectorImage != null)
            {
                // Remove background using default settings
                vectorImage.RemoveBackground(new RemoveBackgroundSettings());
            }

            // Configure PNG options for transparency
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                }
            };

            // Save the processed image as PNG with transparent background
            image.Save(outputFilePath, pngOptions);
        }
    }
}