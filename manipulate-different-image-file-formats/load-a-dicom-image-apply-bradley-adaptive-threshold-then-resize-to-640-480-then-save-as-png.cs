// HOW-TO: Convert DICOM to PNG with Bradley Threshold and Resize in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "Output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.BinarizeBradley(0.15);
                raster.Resize(640, 480);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application needs to preprocess DICOM scans by binarizing them with Bradley adaptive threshold and downscale them to 640×480 for faster web viewing as PNG files.
 * 2. When a radiology workflow requires converting high‑resolution DICOM images to lightweight PNG thumbnails while preserving contrast using Aspose.Imaging’s BinarizeBradley method.
 * 3. When a healthcare data‑export tool must transform DICOM files into PNG format with consistent size for integration into electronic health record (EHR) systems.
 * 4. When a machine‑learning pipeline needs uniformly sized (640×480) binary PNG images generated from DICOM scans for training image classification models.
 * 5. When a desktop C# utility has to batch‑process DICOM images, apply adaptive thresholding, resize them, and save the results as PNG for archival or reporting purposes.
 */
