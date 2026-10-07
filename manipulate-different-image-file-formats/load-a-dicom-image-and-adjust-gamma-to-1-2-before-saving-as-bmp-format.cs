// HOW-TO: Load DICOM Image, Apply Gamma Correction, Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.dcm";
                string outputPath = "output/output.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)dicomImage;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    raster.AdjustGamma(1.2f);

                    BmpOptions bmpOptions = new BmpOptions();
                    dicomImage.Save(outputPath, bmpOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a medical DICOM scan to a BMP file while improving its brightness by applying a gamma of 1.2.
 * 2. When a radiology application must display DICOM images on devices that only support BMP, requiring on‑the‑fly gamma adjustment for better visual contrast.
 * 3. When you are building a batch processor that extracts DICOM frames, normalizes their intensity with gamma correction, and stores them as BMP for archival or reporting purposes.
 * 4. When a diagnostic tool needs to cache large DICOM raster data, modify its gamma, and then export the result to a widely compatible BMP format for third‑party analysis.
 * 5. When integrating Aspose.Imaging into a C# workflow to read DICOM files, apply a specific gamma curve, and generate BMP thumbnails for a PACS web viewer.
 */
