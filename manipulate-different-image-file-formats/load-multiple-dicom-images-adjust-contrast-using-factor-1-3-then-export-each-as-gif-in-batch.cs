// HOW-TO: Batch Convert DICOM Images to GIF with Contrast Adjustment in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)dicom;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }
                    raster.AdjustContrast(1.3f);

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".gif");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (GifOptions gifOptions = new GifOptions())
                    {
                        dicom.Save(outputPath, gifOptions);
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
 * 1. When a hospital needs to quickly generate animated previews of a series of DICOM scans with enhanced contrast for web‑based review.
 * 2. When a research lab wants to export a folder of MRI images to lightweight GIF files after applying a uniform contrast boost for presentation slides.
 * 3. When a medical imaging software vendor must automate the conversion of incoming DICOM files to GIF format for integration with a legacy reporting system.
 * 4. When a developer builds a batch processing tool that normalizes the visual quality of radiology images before archiving them as GIFs for mobile viewing.
 * 5. When a telemedicine platform requires server‑side code to adjust contrast of DICOM images and deliver them as GIFs to browsers without installing specialized viewers.
 */
