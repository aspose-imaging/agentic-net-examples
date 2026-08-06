using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            const int maxAttempts = 3;
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
                    {
                        int pageIndex = 0;
                        foreach (var page in dicom.DicomPages)
                        {
                            string pageOutput = outputPath;
                            if (dicom.DicomPages.Count() > 1)
                            {
                                string dir = Path.GetDirectoryName(outputPath);
                                string name = Path.GetFileNameWithoutExtension(outputPath);
                                string ext = Path.GetExtension(outputPath);
                                pageOutput = Path.Combine(dir, $"{name}_{pageIndex}{ext}");
                            }

                            page.Save(pageOutput, new PngOptions());
                            pageIndex++;
                        }
                    }

                    break;
                }
                catch (Exception)
                {
                    if (attempt == maxAttempts)
                    {
                        throw;
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
 * 1. When a radiology PACS system needs to generate PNG thumbnails of DICOM scans for web preview and must handle transient file‑access errors with a retry loop.
 * 2. When a medical research application batch‑processes multi‑frame DICOM studies into separate PNG images for machine‑learning training and occasional I/O timeouts require automatic retries.
 * 3. When a hospital EMR integrates patient imaging by converting DICOM files to PNG for display on mobile devices, and temporary storage failures need to be recovered without crashing the app.
 * 4. When a diagnostic imaging workflow exports DICOM series to PNG for inclusion in PDF reports and must gracefully retry after brief permission or lock conflicts.
 * 5. When a telemedicine platform streams DICOM images as PNG snapshots to browsers and needs to recover from short network interruptions during the conversion process.
 */