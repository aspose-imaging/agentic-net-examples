using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path (first argument) and output BMP file path (second argument)
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        string outputPath = args.Length > 1 ? args[1] : "output.bmp";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Obtain default vector rasterization options for the loaded image
            var vectorOptions = (VectorRasterizationOptions)image.GetDefaultOptions(
                new object[] { Color.White, image.Width, image.Height });

            // Preserve visual fidelity
            vectorOptions.BackgroundColor = Color.White;
            vectorOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            vectorOptions.SmoothingMode = SmoothingMode.None;

            // Configure BMP saving options
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                // Preserve color depth (24 bits per pixel)
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.VectorRasterizationOptions = vectorOptions;

                // Save the rasterized image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}