// HOW-TO: Adjust Brightness Contrast and Gamma of DICOM and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.dcm");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.AdjustBrightness(50);
                raster.AdjustContrast(0.2f);
                raster.AdjustGamma(1.1f);

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    raster.Save(outputPath, pdfOptions);
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
 * 1. When a radiology application needs to enhance a DICOM X‑ray image’s visibility before archiving it as a searchable PDF report.
 * 2. When a healthcare integration service must programmatically adjust the brightness, contrast, and gamma of medical scans and deliver them to clinicians in PDF format.
 * 3. When a C# desktop tool converts DICOM files to PDF while applying visual corrections to meet diagnostic imaging standards.
 * 4. When an automated batch process prepares DICOM images for patient records by normalizing image tones and exporting them as PDFs.
 * 5. When a telemedicine platform requires on‑the‑fly image enhancement of DICOM scans before embedding them in PDF documents for remote review.
 */
