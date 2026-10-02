// HOW-TO: Convert DICOM to GIF With Floyd Steinberg Dithering And Resize In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)dicom)
                {
                    raster.Resize(1024, 768);
                    GifOptions gifOptions = new GifOptions();
                    raster.Save(outputPath, gifOptions);
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
 * 1. When a medical imaging system needs to generate a web‑friendly GIF preview of a DICOM scan at a specific resolution.
 * 2. When a radiology workflow requires converting high‑resolution DICOM files to smaller GIFs with Floyd‑Steinberg dithering for faster transmission.
 * 3. When a desktop application must display DICOM images in a legacy UI that only supports GIF format and a fixed 1024×768 size.
 * 4. When an automated report generator creates thumbnail GIFs from DICOM studies for inclusion in PDF or HTML reports.
 * 5. When a cloud service processes incoming DICOM uploads, resizes them, applies dithering, and stores them as GIFs for archival or viewer compatibility.
 */
