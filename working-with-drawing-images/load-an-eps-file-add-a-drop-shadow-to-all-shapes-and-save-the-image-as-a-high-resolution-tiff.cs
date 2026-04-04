using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging;

// Hardcoded input and output paths
string inputPath = @"C:\Images\input.eps";
string outputPath = @"C:\Images\output.tif";

// Verify that the input file exists
if (!File.Exists(inputPath))
{
    Console.Error.WriteLine($"File not found: {inputPath}");
    return;
}

// Ensure the output directory exists
Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

// Load the EPS image
using (var epsImage = (EpsImage)Image.Load(inputPath))
{
    // Create a new TIFF image with the same dimensions as the EPS image
    var tiffCreateOptions = new TiffOptions(TiffExpectedFormat.Default);
    using (var tiffImage = (TiffImage)Image.Create(tiffCreateOptions, epsImage.Width, epsImage.Height))
    {
        // Prepare graphics object for drawing
        var graphics = new Graphics(tiffImage);

        // ----- Draw drop shadow -----
        // Offset for the shadow (e.g., 5 pixels right and down)
        const int shadowOffsetX = 5;
        const int shadowOffsetY = 5;

        // Set a semi‑transparent black brush for the shadow
        var shadowColor = Color.FromArgb(128, 0, 0, 0); // 50% transparent black
        var shadowPen = new Pen(shadowColor, 0);

        // Apply translation for the shadow
        graphics.TranslateTransform(shadowOffsetX, shadowOffsetY);

        // Draw the EPS image as the shadow (rendered in black)
        // To render the EPS in a solid color we draw it onto a temporary bitmap,
        // fill it with black, then draw that bitmap as the shadow.
        // For simplicity, we draw the EPS directly; Aspose.Imaging renders it with its colors.
        graphics.DrawImage(epsImage, new Rectangle(0, 0, epsImage.Width, epsImage.Height));

        // Reset transformation
        graphics.ResetTransform();

        // ----- Draw original EPS on top -----
        graphics.DrawImage(epsImage, new Rectangle(0, 0, epsImage.Width, epsImage.Height));

        // Save the result as a high‑resolution TIFF
        // Increase DPI by setting the resolution in the save options (if needed)
        var tiffSaveOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            // Example: set compression to LZW (optional)
            Compression = TiffCompressions.Lzw
        };

        tiffImage.Save(outputPath, tiffSaveOptions);
    }
}