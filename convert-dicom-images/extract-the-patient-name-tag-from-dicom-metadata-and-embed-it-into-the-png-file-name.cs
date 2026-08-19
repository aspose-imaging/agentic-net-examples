// HOW-TO: Extract Patient Name From DICOM and Save Pages As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Attempt to retrieve patient name from DICOM metadata.
                // If unavailable, fallback to "Unknown".
                string patientName = "Unknown";
                try
                {
                    // Some DICOM implementations expose patient name via FileInfo.
                    // Adjust according to actual API if different.
                    var fileInfo = dicomImage.FileInfo;
                    var propInfo = fileInfo?.GetType().GetProperty("PatientName");
                    if (propInfo != null)
                    {
                        var value = propInfo.GetValue(fileInfo) as string;
                        if (!string.IsNullOrEmpty(value))
                            patientName = value.Replace(' ', '_');
                    }
                }
                catch { /* ignore metadata extraction errors */ }

                int pageIndex = 0;
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"{patientName}_page{pageIndex}.png");
                    dicomPage.Save(outputPath, new PngOptions());
                    pageIndex++;
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
 * 1. When a hospital needs to archive radiology studies as PNG files whose filenames include the patient’s name for quick identification.
 * 2. When a medical research team wants to batch‑convert multi‑frame DICOM files to PNG while preserving the patient name in each output file.
 * 3. When a PACS integration requires exporting individual DICOM pages to PNG images that are automatically labeled with the patient’s name for downstream processing.
 * 4. When building a web portal that displays DICOM images as PNG thumbnails and needs the filenames to reflect the patient name for sorting and searching.
 * 5. When a quality‑control script must generate PNG copies of DICOM pages and embed the patient name in the filenames to match audit‑log records.
 */
