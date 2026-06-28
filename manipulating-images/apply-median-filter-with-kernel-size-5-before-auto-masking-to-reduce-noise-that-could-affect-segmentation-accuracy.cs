using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input image path
            string inputPath = @"c:\temp\sample.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hard‑coded output directory for segments
            string outputDir = @"c:\temp\segments\";
            Directory.CreateDirectory(outputDir); // ensure output folder exists

            // Load the source image as a raster image
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;

                // Apply a median filter with kernel size 5 to the whole image
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Prepare auto‑masking arguments (default settings)
                AutoMaskingArgs args = new AutoMaskingArgs();

                // Export options for each segmented image
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking options
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.KMeans,
                    Decompose = true,
                    Args = args,
                    BackgroundReplacementColor = Color.Orange,
                    ExportOptions = exportOptions
                };

                // Create the masking engine
                ImageMasking masking = new ImageMasking(raster);

                // Perform decomposition (segmentation)
                using (MaskingResult result = masking.Decompose(maskingOptions))
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"segment_{result[i].ObjectNumber}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath)); // safety

                        using (Image segmentImg = result[i].GetImage())
                        {
                            segmentImg.Save(outputPath);
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
 * 1. When processing scanned documents with speckle noise, a developer can apply a median filter with kernel size 5 before auto‑masking to isolate text regions and export each segment as a PNG with alpha channel.
 * 2. When cleaning up noisy medical X‑ray images, using the median filter prior to K‑means auto‑masking helps reduce artifacts, allowing accurate segmentation and generation of separate PNG slices for analysis.
 * 3. When preparing product photos taken under low‑light conditions for e‑commerce catalogs, applying the median filter first removes grain, enabling reliable auto‑masking to separate the product from the background and save each mask as a true‑color PNG.
 * 4. When extracting individual components from a complex engineering diagram saved as PNG, the median filter smooths stray pixels, improving auto‑masking accuracy for segmenting each part into separate PNG files with transparent backgrounds.
 * 5. When automating batch processing of satellite imagery stored as PNG files, the median filter reduces sensor noise before auto‑masking, ensuring each land‑cover segment is correctly isolated and exported with alpha transparency.
 */