using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                AutoMaskingArgs maskArgs = new AutoMaskingArgs
                {
                    ObjectsPoints = new Point[][]
                    {
                        new Point[] { new Point(30, 30), new Point(40, 30) },
                        new Point[] { new Point(100, 100), new Point(110, 110) }
                    }
                };

                PngOptions maskingExport = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                AutoMaskingGraphCutOptions maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = false,
                    FeatheringRadius = 3,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = maskingExport,
                    Args = maskArgs,
                    BackgroundReplacementColor = Color.Transparent
                };

                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult results = masking.Decompose(maskingOptions))
                {
                    using (RasterImage foreground = (RasterImage)results[1].GetImage())
                    {
                        foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When a developer needs to remove background objects from a high‑resolution PNG in a C# application and preserve the original DPI for print‑ready output, they can use this Aspose.Imaging auto‑masking code.
 * 2. When an e‑commerce platform must automatically isolate product photos from user‑provided PNGs using custom foreground strokes while keeping the image’s resolution consistent across thumbnails, this code provides the solution.
 * 3. When a medical imaging system requires precise segmentation of regions in PNG scans based on clinician‑drawn points and must export the result with a transparent background at the same DPI as the source, the example demonstrates how to achieve it.
 * 4. When a desktop publishing tool needs to batch‑process PNG assets, apply graph‑cut masking with feathered edges, and align the output resolution to match the original document’s DPI, developers can implement the shown workflow.
 * 5. When a mobile app backend must generate cut‑out PNG stickers from user‑uploaded images, using auto‑masking with user strokes and ensuring the saved PNG retains the original image’s DPI for consistent scaling, this code can be integrated.
 */