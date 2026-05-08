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
                @"C:\Images\dicom1.dcm",
                @"C:\Images\dicom2.dcm"
            };

            // Hard‑coded output directory for PNG files
            string outputDir = @"C:\Images\Converted";

            // Ensure the output directory exists (called before any save)
            Directory.CreateDirectory(outputDir);

            // Process each DICOM file
            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the DICOM image using a stream and load options (high‑performance memory strategy)
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Set a modest buffer size hint to limit internal memory usage
                    LoadOptions loadOptions = new LoadOptions
                    {
                        BufferSizeHint = 256 * 1024 // 256 KB
                    };

                    using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                    {
                        // Adjust gamma for the whole image (applies to all pages)
                        dicomImage.AdjustGamma(2.0f); // example gamma value

                        // Save each page as an individual PNG file
                        foreach (DicomPage page in dicomImage.DicomPages)
                        {
                            // Build output file name: original name + page index
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.Index}.png";
                            string outputPath = Path.Combine(outputDir, outputFileName);

                            // Ensure the directory for this file exists (unconditional as required)
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