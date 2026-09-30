// HOW-TO: Verify Pixel Data Unchanged When Converting DICOM to PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage dicomRaster = (Aspose.Imaging.RasterImage)dicom;
                if (!dicomRaster.IsCached) dicomRaster.CacheData();
                int[] dicomPixels = dicomRaster.LoadArgb32Pixels(dicomRaster.Bounds);

                using (var pngOptions = new PngOptions())
                {
                    dicom.Save(outputPath, pngOptions);
                }

                using (Aspose.Imaging.RasterImage pngRaster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(outputPath))
                {
                    int[] pngPixels = pngRaster.LoadArgb32Pixels(pngRaster.Bounds);

                    bool unchanged = dicomPixels.Length == pngPixels.Length;
                    if (unchanged)
                    {
                        for (int i = 0; i < dicomPixels.Length; i++)
                        {
                            if (dicomPixels[i] != pngPixels[i])
                            {
                                unchanged = false;
                                break;
                            }
                        }
                    }

                    if (unchanged)
                        Console.WriteLine("Pixel data unchanged after conversion.");
                    else
                        Console.WriteLine("Pixel data differs after conversion.");
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
 * 1. When a medical imaging application must ensure that converting DICOM scans to PNG for web display does not alter the original pixel values.
 * 2. When performing automated quality‑control tests on a batch conversion pipeline that transforms DICOM files to PNG and needs to confirm lossless pixel fidelity.
 * 3. When integrating Aspose.Imaging into a diagnostic tool that stores PNG thumbnails of DICOM images and must verify the thumbnails match the source data.
 * 4. When developing a regulatory‑compliant workflow that requires pixel‑perfect preservation after format conversion for radiology archives.
 * 5. When debugging a custom image‑processing routine that caches DICOM raster data and you need to compare it against the resulting PNG pixels.
 */
