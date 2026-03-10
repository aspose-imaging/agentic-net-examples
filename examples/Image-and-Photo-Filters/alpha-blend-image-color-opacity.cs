using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Desired overlay color (red) and opacity (0.5 = 50%)
        Aspose.Imaging.Color overlayColor = Color.FromArgb(255, 255, 0, 0);
        float opacity = 0.5f;

        // Load the source image as a RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Create an overlay image of the same size
            using (RasterImage overlayImage = (RasterImage)Image.Create(new PngOptions(), sourceImage.Width, sourceImage.Height))
            {
                // Fill the overlay with the solid color
                int pixelCount = sourceImage.Width * sourceImage.Height;
                int[] pixels = new int[pixelCount];
                int argb = overlayColor.ToArgb();
                for (int i = 0; i < pixelCount; i++)
                {
                    pixels[i] = argb;
                }
                overlayImage.SaveArgb32Pixels(new Rectangle(0, 0, overlayImage.Width, overlayImage.Height), pixels);

                // Configure the alpha blending filter options
                var blendOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions
                {
                    Image = overlayImage,
                    Opacity = opacity,
                    BlendingMode = Aspose.Imaging.ImageFilters.FilterOptions.BlendingMode.Normal
                };

                // Apply the blending filter to the source image
                sourceImage.Filter(sourceImage.Bounds, blendOptions);
            }

            // Save the blended result as JPEG
            JpegOptions jpegOptions = new JpegOptions { Quality = 90 };
            sourceImage.Save(outputPath, jpegOptions);
        }
    }
}