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
            string[] inputPaths = {
                @"C:\Images\input1.dcm",
                @"C:\Images\input2.dcm"
            };

            // Hardcoded output directory for PNG files
            string outputDirectory = @"C:\Images\Output";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DICOM file as a stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Enable high‑performance memory strategy via LoadOptions
                    var loadOptions = new LoadOptions
                    {
                        // Limit internal buffers to 256 KB (example value)
                        BufferSizeHint = 256 * 1024
                    };

                    // Load the DICOM image with the specified load options
                    using (var dicomImage = new DicomImage(stream, loadOptions))
                    {
                        // Adjust gamma for the whole image (applies to all pages)
                        dicomImage.AdjustGamma(2.2f);

                        // Iterate through each page and save as PNG
                        foreach (DicomPage page in dicomImage.DicomPages)
                        {
                            // Build output file name: inputFileName_pageIndex.png
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
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application must convert a batch of DICOM scans to PNG for web viewing while minimizing memory usage, this code can load each DICOM file with a custom BufferSizeHint, apply a gamma correction, and save every frame as a PNG file.
 * 2. When a radiology research pipeline needs to preprocess multi‑frame DICOM studies by adjusting brightness (gamma) and exporting each slice to a lossless PNG format for downstream analysis, the sample demonstrates the required C# workflow.
 * 3. When a hospital PACS integration requires high‑performance conversion of incoming DICOM images to portable PNG thumbnails for electronic health record (EHR) portals, the code shows how to stream the files, limit internal buffers, and batch‑save the pages.
 * 4. When a diagnostic AI model expects PNG inputs but the source data are DICOM files with varying pixel intensity, developers can use this snippet to load the DICOM images, normalize gamma, and generate PNG datasets without exhausting server memory.
 * 5. When a desktop utility must automate the extraction of every frame from multi‑page DICOM files and store them as PNG files for archiving or printing, the example provides the necessary C# steps to iterate pages, adjust gamma, and write the output files.
 */