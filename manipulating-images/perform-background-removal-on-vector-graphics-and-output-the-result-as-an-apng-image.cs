using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input vector image path (e.g., SVG, CDR, etc.)
        string inputPath = "input.svg";
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Remove background if the image is a vector image
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground(new RemoveBackgroundSettings());
            }

            // Configure APNG options with transparent background and rasterization settings
            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                }
            };

            // Save the image as APNG
            image.Save(outputPath, apngOptions);
        }
    }
}