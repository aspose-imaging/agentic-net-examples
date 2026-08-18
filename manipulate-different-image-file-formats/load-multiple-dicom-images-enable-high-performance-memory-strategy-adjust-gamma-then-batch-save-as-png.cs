// HOW-TO: Batch Convert DICOM Images to PNG with Gamma Adjustment in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DICOM files
            string[] inputFiles = new string[]
            {
                @"C:\Images\dicom1.dcm",
                @"C:\Images\dicom2.dcm"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Configure high‑performance memory strategy
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB buffer hint
                };

                // Load DICOM image from stream with the specified load options
                using (FileStream stream = File.OpenRead(inputPath))
                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Adjust gamma for the entire image
                    dicomImage.AdjustGamma(2.2f);

                    int pageIndex = 0;
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        // Build output PNG file path
                        string outputPath = Path.Combine(
                            outputDir,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.png");

                        // Ensure the output directory exists (unconditional as required)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());

                        pageIndex++;
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
 * 1. When a medical imaging application needs to export each DICOM slice as a gamma‑corrected PNG for web viewing.
 * 2. When a radiology workflow requires fast, low‑memory loading of large DICOM files before converting them to a portable format.
 * 3. When a research project must process multiple DICOM studies and generate PNG thumbnails with consistent brightness.
 * 4. When a hospital PACS integration needs to batch‑convert DICOM series to PNG while preserving image contrast via gamma correction.
 * 5. When a developer wants to automate the conversion of DICOM files to PNG on a server using a buffered memory strategy to improve performance.
 */
