using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DICOM image
            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                // Save the image as PNG
                using (PngOptions pngOptions = new PngOptions())
                {
                    dicom.Save(outputPath, pngOptions);
                }
            }

            // Compare file sizes
            long dicomSize = new FileInfo(inputPath).Length;
            long pngSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"DICOM size: {dicomSize} bytes");
            Console.WriteLine($"PNG size: {pngSize} bytes");
            Console.WriteLine(pngSize < dicomSize ? "PNG is smaller than DICOM." : "PNG is not smaller than DICOM.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to convert DICOM scans to PNG thumbnails for quick preview in a web portal while checking that the PNG file is smaller than the original DICOM.
 * 2. When a hospital’s PACS integration test must verify that converting a sample DICOM image to PNG using Aspose.Imaging for .NET produces a valid PNG file and that the file size reduction meets storage optimization goals.
 * 3. When a developer is building an automated quality‑control pipeline that loads a DICOM file, saves it as PNG, and compares the byte sizes to ensure the conversion does not increase storage consumption.
 * 4. When a research team wants to extract visual data from DICOM files for machine‑learning preprocessing and needs a unit test that confirms the PNG output is correctly generated and smaller than the source DICOM.
 * 5. When a software vendor needs to demonstrate that their C# code can safely handle missing input files, create output directories, and perform DICOM‑to‑PNG conversion with Aspose.Imaging while reporting size differences for compliance documentation.
 */