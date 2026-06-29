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
            // Hard‑coded input DICOM files
            string[] inputPaths = new string[]
            {
                @"C:\Images\dicom1.dcm",
                @"C:\Images\dicom2.dcm"
            };

            // Hard‑coded output directory
            string outputDir = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DICOM file as a stream
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Enable high‑performance memory strategy via LoadOptions
                    LoadOptions loadOptions = new LoadOptions
                    {
                        BufferSizeHint = 256 * 1024 // 256 KB buffer size hint
                    };

                    // Load the DICOM image with the specified load options
                    using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                    {
                        // Adjust gamma for the whole image
                        dicomImage.AdjustGamma(2.2f);

                        // Save each page as an individual PNG file
                        foreach (DicomPage page in dicomImage.DicomPages)
                        {
                            string outputPath = Path.Combine(
                                outputDir,
                                $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.Index}.png");

                            // Ensure the directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            page.Save(outputPath, new PngOptions());
                        }
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
 * 1. When a medical imaging application must convert a batch of DICOM scans to PNG for web viewing while applying gamma correction to improve brightness.
 * 2. When a radiology research tool needs to load large DICOM files efficiently using a custom buffer size and then export each slice as a separate PNG for analysis in image‑processing pipelines.
 * 3. When a hospital PACS integration requires automated conversion of multi‑frame DICOM studies to PNG thumbnails with adjusted gamma for consistent display on mobile devices.
 * 4. When a diagnostic software vendor wants to preprocess DICOM images by adjusting gamma and then save them as PNG to embed in PDF reports without loading the entire file into memory.
 * 5. When a cloud‑based health‑tech service processes incoming DICOM files, uses high‑performance memory strategy to handle high‑resolution scans, and outputs gamma‑corrected PNGs for machine‑learning model training.
 */