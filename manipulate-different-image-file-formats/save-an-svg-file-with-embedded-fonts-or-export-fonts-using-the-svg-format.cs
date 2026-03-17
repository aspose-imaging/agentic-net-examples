using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SaveSvgWithEmbeddedFonts
{
    static void Main()
    {
        // Input WMF (or any vector) file path
        string inputPath = @"C:\temp\test.wmf";

        // Output SVG file path – fonts will be embedded
        string outputPath = @"C:\temp\test_with_fonts.svg";

        // Load the vector image using the unified Image.Load method
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Create SVG save options
            SvgOptions svgOptions = new SvgOptions();

            // Keep text as text (do NOT convert to shapes) so fonts can be embedded
            svgOptions.TextAsShapes = false;

            // Assign the default resource keeper callback – it handles font and image resources
            svgOptions.Callback = new SvgResourceKeeperCallback();

            // Configure rasterization options specific to WMF
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,                     // Preserve original size
                BackgroundColor = Color.White,                // Optional background
                RenderMode = WmfRenderMode.Auto               // Auto-select rendering mode
            };

            // Attach rasterization options to the SVG options
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as SVG with embedded fonts
            wmfImage.Save(outputPath, svgOptions);
        }

        Console.WriteLine("SVG saved with embedded fonts to: " + outputPath);
    }
}