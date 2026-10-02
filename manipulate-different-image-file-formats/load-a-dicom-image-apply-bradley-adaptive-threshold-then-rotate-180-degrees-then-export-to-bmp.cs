// HOW-TO: Convert DICOM to BMP with Bradley Threshold and 180° Rotation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.dcm";
        string outputPath = "Output\\result.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterCachedImage raster = image as RasterCachedImage;
                if (raster != null)
                {
                    if (!raster.IsCached) raster.CacheData();
                    raster.BinarizeBradley(0.15, 15);
                }

                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    image.Save(outputPath, bmpOptions);
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
 * 1. When you need to preprocess a DICOM X‑ray by binarizing it with Bradley adaptive threshold, flip it upside‑down, and store the result as a BMP for legacy Windows applications.
 * 2. When a medical imaging workflow requires converting DICOM scans to a lossless BMP format after applying contrast‑enhancing thresholding and a 180° rotation for correct orientation.
 * 3. When integrating Aspose.Imaging in a C# service that automatically prepares DICOM images for OCR by thresholding, rotating, and saving them as BMP files.
 * 4. When building a batch processor that reads DICOM files, applies adaptive binarization, corrects the image orientation, and outputs BMPs for archival or further analysis.
 * 5. When a developer must generate BMP thumbnails from DICOM studies with Bradley thresholding and a 180° rotation to match the viewing direction of a downstream reporting tool.
 */
