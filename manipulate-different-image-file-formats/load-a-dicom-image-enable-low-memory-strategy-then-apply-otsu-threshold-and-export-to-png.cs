// HOW-TO: Convert DICOM to PNG with Otsu Binarization Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.dcm";
            string outputPath = "Output\\image.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                RasterCachedImage raster = (RasterCachedImage)dicom;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.BinarizeOtsu();

                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.Source = new FileCreateSource(outputPath, false);
                    raster.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application needs to display a DICOM scan on a web page, developers can convert the DICOM file to a lightweight PNG after applying Otsu threshold for clear binary visualization.
 * 2. When processing large DICOM datasets on a server with limited RAM, the low‑memory caching strategy lets developers binarize images without exhausting resources.
 * 3. When preparing DICOM images for machine‑learning preprocessing, applying Otsu binarization and exporting to PNG provides a standardized binary input format.
 * 4. When integrating Aspose.Imaging into a C# desktop tool that extracts regions of interest from radiology images, the code enables fast conversion and thresholding in a single step.
 * 5. When automating batch conversion of DICOM files to PNG for archival or reporting, developers can reuse this snippet to ensure each image is thresholded and saved efficiently.
 */
