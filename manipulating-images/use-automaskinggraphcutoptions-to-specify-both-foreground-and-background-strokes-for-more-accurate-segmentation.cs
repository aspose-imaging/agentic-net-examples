using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPathInitial = "output_initial.png";
            string outputPathRefined = "output_refined.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathInitial));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathRefined));

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // First pass: calculate default background and foreground strokes
                var options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult initialResult = new ImageMasking(image).Decompose(options))
                {
                    // Save the initial foreground result
                    using (RasterImage foreground = (RasterImage)initialResult[1].GetImage())
                    {
                        foreground.Save(outputPathInitial, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }

                    // Retrieve the automatically calculated strokes
                    Point[] backgroundStrokes = options.DefaultBackgroundStrokes;
                    Point[] foregroundStrokes = options.DefaultForegroundStrokes;

                    // Second pass: use both background and foreground strokes for refined segmentation
                    options.CalculateDefaultStrokes = false;
                    options.Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][]
                        {
                            backgroundStrokes,   // background points
                            foregroundStrokes    // foreground points
                        }
                    };

                    using (MaskingResult refinedResult = new ImageMasking(image).Decompose(options))
                    {
                        // Save the refined foreground result
                        using (RasterImage refinedForeground = (RasterImage)refinedResult[1].GetImage())
                        {
                            refinedForeground.Save(outputPathRefined, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically remove a product from a cluttered photograph and export it as a PNG with a transparent background for e‑commerce catalogs.
 * 2. When an application must isolate a person’s silhouette from a complex outdoor scene to create a cut‑out for marketing graphics using C# and Aspose.Imaging’s GraphCut segmentation.
 * 3. When a photo‑editing tool requires precise foreground extraction for images with similar colors between subject and background, leveraging AutoMaskingGraphCutOptions to generate default strokes and refine the mask.
 * 4. When a batch‑processing service processes scanned documents containing stamps or signatures and needs to separate those elements from the paper background before saving as PNG with an alpha channel.
 * 5. When a mobile‑backend service prepares avatar images by separating the face from varied backgrounds, using the GraphCut method and feathering radius to produce smooth edges in the resulting PNG file.
 */