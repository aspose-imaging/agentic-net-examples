using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define input SVG and output BMP file paths
        string inputPath = "input.svg";
        string outputPath = "output.bmp";

        // Load the SVG image
        using (Image svgImage = Image.Load(inputPath))
        {
            // Configure BMP options with high resolution (e.g., 300 DPI)
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                // Set up vector rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Specify the output file via FileCreateSource
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                // Create the BMP canvas with the same dimensions as the source SVG
                using (Image bmpCanvas = Image.Create(bmpOptions, svgImage.Width, svgImage.Height))
                {
                    // Save the BMP image (Canvas.Save() is required when using FileCreateSource)
                    bmpCanvas.Save();
                }
            }
        }
    }
}