using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path and output TIFF file path.
        string inputSvgPath = "input.svg";
        string outputTiffPath = "output.tif";

        // Load the SVG image using Aspose.Imaging.
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Configure rasterization options for the SVG.
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Preserve the original SVG dimensions.
                PageSize = svgImage.Size,
                // Set a white background to maintain color fidelity.
                BackgroundColor = Color.White,
                // Enable anti-aliasing for smoother edges.
                SmoothingMode = SmoothingMode.AntiAlias,
                // Render text with anti-aliasing.
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Configure TIFF save options.
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                // Use LZW compression for good size/quality balance.
                Compression = TiffCompressions.Lzw,
                // Set desired resolution (DPI) for the rasterized output.
                ResolutionSettings = new ResolutionSetting(300, 300),
                // Attach the rasterization options to the TIFF export.
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as a TIFF file.
            svgImage.Save(outputTiffPath, tiffOptions);
        }
    }
}