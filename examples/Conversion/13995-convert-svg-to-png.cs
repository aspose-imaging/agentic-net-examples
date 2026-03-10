using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path and output PNG file path
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage for SVG-specific properties
            SvgImage svgImage = (SvgImage)image;

            // Configure rasterization options for SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the SVG dimensions
                PageSize = svgImage.Size,
                // Optional: set background color
                BackgroundColor = Color.White
            };

            // Set PNG export options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}