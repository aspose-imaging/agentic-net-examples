using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path and desired output PNG path
        string inputSvgPath = "input.svg";
        string outputPngPath = "output.png";

        // Desired dimensions for the resulting PNG bitmap
        int targetWidth = 800;
        int targetHeight = 600;

        // Load the SVG image using Aspose.Imaging.Image.Load
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Ensure the loaded image is a vector image
            if (!(svgImage is VectorImage))
                throw new InvalidOperationException("The provided file is not a vector image.");

            // Calculate uniform scaling factor to fit the SVG within the target dimensions while preserving aspect ratio
            float scaleX = (float)targetWidth / svgImage.Width;
            float scaleY = (float)targetHeight / svgImage.Height;
            float uniformScale = Math.Min(scaleX, scaleY);

            // Configure rasterization options for SVG rendering
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                ScaleX = uniformScale,
                ScaleY = uniformScale,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                BackgroundColor = Color.White
            };

            // Set up PNG export options and attach the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized PNG image to the specified path
            svgImage.Save(outputPngPath, pngOptions);
        }
    }
}