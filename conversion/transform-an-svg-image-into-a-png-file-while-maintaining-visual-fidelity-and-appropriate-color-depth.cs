using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging;

// Path to the source SVG file
string inputSvgPath = @"C:\Images\source.svg";
// Path where the PNG will be saved
string outputPngPath = @"C:\Images\converted.png";

// Open the SVG file as a stream and load it into a SvgImage instance
using (FileStream svgStream = File.OpenRead(inputSvgPath))
using (SvgImage svgImage = new SvgImage(svgStream))
{
    // Configure rasterization options to preserve the original dimensions and quality
    var rasterOptions = new SvgRasterizationOptions
    {
        // Use the original SVG size for the rasterized image
        PageSize = svgImage.Size,
        // Optional: set a white background to avoid transparency issues
        BackgroundColor = Color.White,
        // High‑quality text rendering
        TextRenderingHint = TextRenderingHint.AntiAliasGridFit,
        // High‑quality smoothing for vector shapes
        SmoothingMode = SmoothingMode.HighQuality
    };

    // Configure PNG save options, setting a standard 8‑bit depth for good color fidelity
    var pngOptions = new PngOptions
    {
        BitDepth = 8,
        VectorRasterizationOptions = rasterOptions
    };

    // Save the rasterized image as PNG
    svgImage.Save(outputPngPath, pngOptions);
}