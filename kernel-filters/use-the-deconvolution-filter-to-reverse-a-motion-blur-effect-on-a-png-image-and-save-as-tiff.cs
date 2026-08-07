using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\blurred.png";
        string outputPath = "Output\\restored.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0);
                raster.Filter(raster.Bounds, filterOptions);

                using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    raster.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to restore a motion‑blurred PNG screenshot taken from a video frame and archive the cleaned result as a high‑quality TIFF for legal evidence.
 * 2. When an image‑processing pipeline must automatically deblur scanned PNG documents captured with a moving camera and output them as TIFF files for downstream OCR.
 * 3. When a photo‑editing application built in C# wants to offer a “undo motion blur” feature that reads a PNG, applies the MotionWiener deconvolution filter, and saves the corrected image in TIFF format for lossless storage.
 * 4. When a batch job processes a folder of blurred PNG assets from a surveillance system, uses Aspose.Imaging’s filter API to reverse the blur, and stores the restored images as TIFFs for archival compliance.
 * 5. When a scientific imaging tool requires converting motion‑blurred PNG microscopy images into deblurred TIFF files to preserve pixel fidelity for further analysis.
 */