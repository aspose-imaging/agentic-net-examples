using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;

class RecursiveAutoMasking
{
    static void Main()
    {
        // Path to the source image
        const string inputPath = "input.jpg";

        // -----------------------------------------------------------------
        // First masking pass – calculate default strokes automatically
        // -----------------------------------------------------------------
        MaskingResult[] firstResults;
        AutoMaskingGraphCutOptions autoOptions;

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            autoOptions = new AutoMaskingGraphCutOptions
            {
                // Let the algorithm compute default background/foreground strokes
                CalculateDefaultStrokes = true,
                // Small feathering to smooth edges
                FeatheringRadius = 3,
                // Use GraphCut segmentation
                Method = SegmentationMethod.GraphCut,
                // We want a single composited image (not decomposed into separate objects)
                Decompose = false,
                // Export options – truecolor with alpha channel
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    // Temporary file – the actual image will be obtained from the result object
                    Source = new FileCreateSource("temp1.png")
                },
                // Make background transparent
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform the first masking operation
            firstResults = new ImageMasking(sourceImage).Decompose(autoOptions);
        }

        // Save the first pass result (optional, for inspection)
        using (RasterImage firstResultImage = (RasterImage)firstResults[1].GetImage())
        {
            firstResultImage.Save("step1.png", new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }

        // -----------------------------------------------------------------
        // Retrieve the automatically calculated strokes
        // -----------------------------------------------------------------
        Point[] backgroundStrokes = autoOptions.DefaultBackgroundStrokes;
        Point[] foregroundStrokes = autoOptions.DefaultForegroundStrokes;
        Rectangle[] objectRectangles = autoOptions.DefaultObjectsRectangles;

        // -----------------------------------------------------------------
        // Add new custom points to the existing strokes
        // (In a real scenario these could come from user interaction)
        // -----------------------------------------------------------------
        // Example: add a point to background strokes
        Array.Resize(ref backgroundStrokes, backgroundStrokes.Length + 1);
        backgroundStrokes[backgroundStrokes.Length - 1] = new Point(50, 50);

        // Example: add a point to foreground strokes
        Array.Resize(ref foregroundStrokes, foregroundStrokes.Length + 1);
        foregroundStrokes[foregroundStrokes.Length - 1] = new Point(200, 200);

        // -----------------------------------------------------------------
        // Second masking pass – reuse default strokes and include the new points
        // -----------------------------------------------------------------
        MaskingResult[] secondResults;
        GraphCutMaskingOptions secondOptions = new GraphCutMaskingOptions
        {
            FeatheringRadius = 3,
            Method = SegmentationMethod.GraphCut,
            Decompose = false,
            // Export as APNG – Aspose.Imaging treats animated PNG the same as PNG,
            // the file extension determines the format.
            ExportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource("output.apng") // .apng extension for animated PNG
            },
            BackgroundReplacementColor = Color.Transparent,
            // Combine default strokes with the newly added points
            Args = new AutoMaskingArgs
            {
                ObjectsPoints = new Point[][]
                {
                    backgroundStrokes, // background points
                    foregroundStrokes  // foreground points
                },
                // Preserve the automatically detected object rectangles
                ObjectsRectangles = objectRectangles
            }
        };

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            secondResults = new ImageMasking(sourceImage).Decompose(secondOptions);
        }

        // Save the final result as APNG
        using (RasterImage finalImage = (RasterImage)secondResults[1].GetImage())
        {
            finalImage.Save("output.apng", new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }
    }
}