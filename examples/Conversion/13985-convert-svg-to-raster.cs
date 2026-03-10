using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SvgToRasterConversion
{
    static void Main()
    {
        // Paths to the source SVG and the desired raster outputs
        string svgPath = @"C:\Temp\example.svg";
        string pngPath = @"C:\Temp\example.png";
        string jpegPath = @"C:\Temp\example.jpg";

        // Load the SVG image using the unified Image.Load method
        using (Image svgImage = Image.Load(svgPath))
        {
            // Configure rasterization options – keep original size, set a white background,
            // enable anti‑aliasing for smoother lines and text.
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // ---------- Save as PNG ----------
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };
            svgImage.Save(pngPath, pngOptions);

            // ---------- Save as JPEG ----------
            JpegOptions jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = rasterOptions,
                Quality = 90 // Adjust JPEG quality as needed
            };
            svgImage.Save(jpegPath, jpegOptions);
        }
    }
}