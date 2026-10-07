// HOW-TO: How To Convert DICOM To PNG And Compare File Sizes In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
                dicomImage.Save(outputPath, pngOptions);
            }

            long dicomSize = new FileInfo(inputPath).Length;
            long pngSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"DICOM size: {dicomSize} bytes");
            Console.WriteLine($"PNG size: {pngSize} bytes");
            Console.WriteLine($"Size difference: {pngSize - dicomSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to generate lightweight PNG previews of DICOM scans for web display and verify that the conversion reduces file size.
 * 2. When a radiology workflow requires automated batch processing that converts DICOM files to PNG and logs size differences for storage optimization.
 * 3. When a QA engineer writes a unit test to ensure the Aspose.Imaging DICOM‑to‑PNG conversion produces a valid PNG file and correctly reports the byte count.
 * 4. When a developer integrates Aspose.Imaging into a C# service that must compare original DICOM sizes with PNG outputs to decide whether to archive or discard the original.
 * 5. When a healthcare IT system needs to validate that converting confidential DICOM images to PNG does not unintentionally increase data size before transmitting them to a client application.
 */
