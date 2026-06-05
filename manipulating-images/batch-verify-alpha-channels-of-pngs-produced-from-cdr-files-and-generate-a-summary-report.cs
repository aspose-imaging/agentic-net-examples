using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hard‑coded input folder containing PNG files generated from CDR files
        string inputFolder = @"C:\Images\Input";
        // Hard‑coded path for the summary report
        string outputReportPath = @"C:\Images\Report\alpha_report.txt";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputReportPath));

            // Get all PNG files in the input folder (non‑recursive)
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            using (var writer = new StreamWriter(outputReportPath))
            {
                // Write CSV header
                writer.WriteLine("FileName,HasAlpha");

                foreach (string filePath in pngFiles)
                {
                    // Verify the file exists before processing
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    bool hasAlpha = false;

                    // Load the image using Aspose.Imaging
                    using (Image image = Image.Load(filePath))
                    {
                        // Most image types expose HasAlpha via RasterImage
                        if (image is RasterImage rasterImage)
                        {
                            hasAlpha = rasterImage.HasAlpha;
                        }
                        // Specific PNG handling (optional, same as RasterImage)
                        else if (image is PngImage pngImage)
                        {
                            hasAlpha = pngImage.HasAlpha;
                        }
                        // Fallback for other formats that might be encountered
                        else if (image is IcoImage icoImage)
                        {
                            hasAlpha = icoImage.HasAlpha;
                        }
                        else if (image is DjvuImage djvuImage)
                        {
                            hasAlpha = djvuImage.HasAlpha;
                        }
                        else if (image is DicomImage dicomImage)
                        {
                            hasAlpha = dicomImage.HasAlpha;
                        }
                        else if (image is TiffImage tiffImage)
                        {
                            hasAlpha = tiffImage.HasAlpha;
                        }
                        // If none of the above, default to false
                    }

                    // Write result to the report
                    writer.WriteLine($"{Path.GetFileName(filePath)},{hasAlpha}");
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
 * 1. When a graphic design studio needs to confirm that PNG exports from CorelDRAW (.cdr) retain transparency before publishing to a web gallery, they can run this batch verification to list which files have an alpha channel.
 * 2. When an automated build pipeline for a marketing campaign must validate that all product images generated from CDR files contain proper alpha channels for overlaying on variable backgrounds, the code can produce a quick report.
 * 3. When a QA engineer is testing a conversion tool that turns CDR files into PNGs and must ensure no loss of transparency, they can use this script to scan the output folder and record the presence of alpha channels.
 * 4. When a content management system imports PNG assets derived from CDR artwork and needs to flag images lacking alpha for manual correction, the batch check and CSV summary help identify those files.
 * 5. When a developer integrates Aspose.Imaging into a .NET application that processes bulk image assets and wants to generate a log of which PNGs from CDR sources include an alpha channel for downstream processing, this code provides the necessary verification and reporting.
 */