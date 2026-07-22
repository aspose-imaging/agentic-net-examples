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
            string[] inputPaths = {
                @"C:\Images\input1.dcm",
                @"C:\Images\input2.dcm"
            };

            // Hard‑coded output directory for PNG files
            string outputDirectory = @"C:\Images\Output";

            // Process each DICOM file
            foreach (string inputPath in inputPaths)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Set a buffer size hint for high‑performance memory usage
                var loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB
                };

                // Load the DICOM image from a file stream using the load options
                using (Stream stream = File.OpenRead(inputPath))
                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Apply gamma correction (example value)
                    dicomImage.AdjustGamma(2.2f);

                    // Save each page as an individual PNG file
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        // Build the output file name
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.Index}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging application must convert a series of DICOM scans to PNG for web viewing while minimizing memory usage, a developer can use this code to load each DICOM file with a buffer hint, apply gamma correction, and save each frame as a PNG.
 * 2. When a radiology research pipeline needs to preprocess large DICOM datasets by normalizing brightness (gamma) and exporting individual slices as PNG for machine‑learning models, this code provides a fast, stream‑based conversion.
 * 3. When a hospital PACS integration requires batch exporting of multi‑page DICOM studies to portable PNG files for patient reports, the code demonstrates how to iterate through DICOM pages, adjust contrast, and write PNGs to a designated folder.
 * 4. When a desktop utility must quickly transform multiple DICOM files stored on disk into high‑quality PNG thumbnails for a picture‑gallery UI, the buffer‑size hint and gamma adjustment ensure responsive performance.
 * 5. When a developer builds an automated backup script that archives DICOM images as lossless PNGs with consistent gamma levels, this example shows how to verify file existence, create output directories, and process each file in a loop.
 */