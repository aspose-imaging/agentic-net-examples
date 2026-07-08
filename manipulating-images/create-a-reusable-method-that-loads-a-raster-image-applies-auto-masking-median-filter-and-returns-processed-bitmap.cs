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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                var maskExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = maskExportOptions,
                    BackgroundReplacementColor = Color.Transparent
                };

                ImageMasking masking = new ImageMasking(sourceImage);
                using (MaskingResult maskResult = masking.Decompose(maskingOptions))
                using (RasterImage foregroundMask = maskResult[1].GetMask())
                {
                    foregroundMask.Resize(sourceImage.Width, sourceImage.Height, ResizeType.NearestNeighbourResample);

                    using (RasterImage maskedImage = (RasterImage)Image.Load(inputPath))
                    {
                        ImageMasking.ApplyMask(maskedImage, foregroundMask, maskingOptions);
                        maskedImage.Filter(maskedImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                        var saveOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha
                        };
                        maskedImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to automatically remove the background from product photos stored as PNG files and generate a transparent PNG for e‑commerce catalogs.
 * 2. When an image‑processing pipeline must isolate foreground objects in scanned documents, apply a median filter to reduce noise, and output a clean bitmap for OCR preprocessing.
 * 3. When a mobile app backend processes user‑uploaded selfies, using Aspose.Imaging auto‑masking to separate the person from the scene and then smoothing the mask with a median filter before saving a PNG with an alpha channel.
 * 4. When a digital asset management system requires batch conversion of legacy raster images to uniformly sized PNGs with transparent backgrounds, leveraging GraphCut segmentation and median filtering to maintain edge quality.
 * 5. When a scientific imaging application needs to extract cells from microscope PNG images, apply noise‑reducing median filtering, and return a processed raster image for further quantitative analysis.
 */