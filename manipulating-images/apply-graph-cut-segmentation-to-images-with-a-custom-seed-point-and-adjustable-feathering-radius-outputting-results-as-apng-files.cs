using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;

class GraphCutSegmentationExample
{
    static void Main()
    {
        // Input image path
        string inputPath = "input.jpg";

        // Output APNG path (the result will be saved as an animated PNG)
        string outputPath = "segmented_output.apng";

        // Custom seed point (foreground) – adjust as needed
        int seedX = 150;
        int seedY = 200;

        // Load the source image (lifecycle rule)
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Calculate an adjustable feathering radius based on image dimensions
            int featheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1;

            // Configure GraphCut masking options (feature rule)
            GraphCutMaskingOptions options = new GraphCutMaskingOptions
            {
                FeatheringRadius = featheringRadius,
                Method = SegmentationMethod.GraphCut,
                Decompose = false, // we want a single foreground mask
                BackgroundReplacementColor = Color.Transparent,
                // Export options – the temporary file will later be saved as APNG
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath) // APNG file
                },
                // Provide the seed point as a foreground point.
                // The first array is treated as background points (empty here),
                // the second array as foreground points.
                Args = new AutoMaskingArgs
                {
                    ObjectsPoints = new Point[][]
                    {
                        new Point[0],                     // background points (none)
                        new Point[] { new Point(seedX, seedY) } // foreground seed point
                    }
                }
            };

            // Perform the segmentation (lifecycle rule)
            MaskingResult[] results = new ImageMasking(image).Decompose(options);

            // Retrieve the foreground mask (index 1 corresponds to the foreground object)
            using (RasterImage resultImage = (RasterImage)results[1].GetImage())
            {
                // Save the result as an APNG (using the same export options)
                resultImage.Save(outputPath, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                });
            }
        }
    }
}