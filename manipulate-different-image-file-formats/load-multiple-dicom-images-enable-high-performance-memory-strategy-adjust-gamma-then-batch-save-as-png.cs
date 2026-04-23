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
            string[] inputPaths = { "input1.dcm", "input2.dcm" };
            // Hard‑coded output directory
            string outputDir = "output";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Configure load options for a small buffer (high‑performance memory strategy)
                var loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB
                };

                // Open the DICOM file as a stream and load it with the specified options
                using (Stream stream = File.OpenRead(inputPath))
                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Cache all pages to avoid further I/O during processing
                    dicomImage.CacheData();

                    // Apply gamma correction to the whole image
                    dicomImage.AdjustGamma(2.2f);

                    int pageIndex = 0;
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        // Build output file name for each page
                        string outputPath = Path.Combine(
                            outputDir,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.png");

                        // Ensure the output directory exists
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