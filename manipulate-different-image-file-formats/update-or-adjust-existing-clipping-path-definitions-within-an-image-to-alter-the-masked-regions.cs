using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class UpdateClippingPathExample
{
    static void Main()
    {
        // Load the source image
        using (RasterImage image = (RasterImage)Image.Load("input.png"))
        {
            // -------------------------------------------------
            // Step 1: Create an initial clipping path (mask)
            // -------------------------------------------------
            GraphicsPath clippingPath = new GraphicsPath();

            // Add an initial ellipse shape to the mask
            clippingPath.AddFigure(new Figure(new EllipseShape(new RectangleF(50, 50, 200, 150))));

            // -------------------------------------------------
            // Step 2: Adjust the clipping path – add a rectangle
            // -------------------------------------------------
            // This simulates updating existing clipping definitions
            clippingPath.AddFigure(new Figure(new RectangleShape(new RectangleF(120, 120, 100, 80))));

            // -------------------------------------------------
            // Step 3: Prepare manual masking arguments using the updated path
            // -------------------------------------------------
            ManualMaskingArgs manualArgs = new ManualMaskingArgs
            {
                Mask = clippingPath
            };

            // -------------------------------------------------
            // Step 4: Configure masking options
            // -------------------------------------------------
            MaskingOptions maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.Manual,   // Use manual mask
                Decompose = false,                    // Keep result as a single image
                Args = manualArgs,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource("output.png")
                }
            };

            // -------------------------------------------------
            // Step 5: Perform masking with the updated clipping path
            // -------------------------------------------------
            ImageMasking masking = new ImageMasking(image);
            using (Masking.Result.MaskingResult result = masking.Decompose(maskingOptions))
            {
                // Retrieve the processed image (masked result)
                using (Image resultImage = result.GetImage())
                {
                    // Save the final image
                    resultImage.Save("output.png", new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
                }
            }
        }
    }
}