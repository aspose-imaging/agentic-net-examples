using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Loads a raster image, applies auto‑masking and a median filter, then returns the processed image.
    static RasterImage LoadAndProcess(string inputPath)
    {
        // Load the image (no using – the caller will dispose it)
        var image = (RasterImage)Image.Load(inputPath);

        // ---------- Auto‑masking ----------
        // Prepare default auto‑masking arguments
        var autoMaskArgs = new AutoMaskingArgs();

        // Create masking instance for the loaded image
        var masking = new ImageMasking(image);

        // Configure masking options (using KMeans as a generic auto‑masking method)
        var maskingOptions = new MaskingOptions
        {
            Method = SegmentationMethod.KMeans,
            Decompose = true,
            Args = autoMaskArgs,
            BackgroundReplacementColor = Color.Transparent,
            ExportOptions = new PngOptions() // export options are required but not used here
        };

        // Decompose the image to obtain a mask and apply it back to the original image
        using (var maskingResult = masking.Decompose(maskingOptions))
        {
            // Take the first segment mask (usually the foreground)
            using (var mask = maskingResult[0].GetMask())
            {
                // Apply the mask to the original image
                ImageMasking.ApplyMask(image, mask, maskingOptions);
            }
        }

        // ---------- Median filter ----------
        // Apply a median filter with a kernel size of 5 to the whole image
        image.Filter(image.Bounds, new MedianFilterOptions(5));

        return image;
    }

    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? ".");

        // Process the image
        RasterImage processedImage = LoadAndProcess(inputPath);

        // Save the processed image as PNG
        processedImage.Save(outputPath, new PngOptions());

        // Dispose the image after saving
        processedImage.Dispose();
    }
}