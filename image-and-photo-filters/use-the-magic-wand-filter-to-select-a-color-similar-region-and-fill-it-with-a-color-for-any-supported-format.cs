using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the source image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask selecting a region similar to the color at (120, 100) with a threshold of 150
            var mask = MagicWandTool.Select(image, new MagicWandSettings(120, 100) { Threshold = 150 });

            // Load all pixels of the image
            var pixels = image.LoadPixels(image.Bounds);

            // Define the fill color (red with full opacity)
            var fillColor = Color.FromArgb(255, 255, 0, 0);

            // Replace pixels inside the selected mask with the fill color
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (mask.IsOpaque(x, y))
                    {
                        int index = y * image.Width + x;
                        pixels[index] = fillColor;
                    }
                }
            }

            // Save the modified pixels back to the image
            image.SavePixels(image.Bounds, pixels);

            // Save the result as PNG with alpha channel
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };
            image.Save(outputPath, pngOptions);
        }
    }
}