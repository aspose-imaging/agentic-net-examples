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
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the source PNG image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            // Prepare output source and PNG options (transparent canvas)
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions
            {
                Source = outSource,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create a new blank PNG canvas with the same dimensions
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
            {
                // Fill the entire canvas with fully transparent pixels (ARGB = 0)
                int[] transparentPixels = new int[width * height]; // default zeros are transparent
                canvas.SaveArgb32Pixels(new Rectangle(0, 0, width, height), transparentPixels);

                // Save the transparent canvas to the output file
                canvas.Save();
            }
        }
    }
}