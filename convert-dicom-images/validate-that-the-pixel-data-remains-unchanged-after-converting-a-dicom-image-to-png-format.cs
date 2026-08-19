// HOW-TO: Verify Pixel Data Integrity When Converting DICOM to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DICOM file path
            string inputPath = "input.dcm";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Directory where PNG pages will be saved
            string outputDir = "output";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir) ?? ".");

            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Iterate through each DICOM page
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Load original ARGB32 pixel data from the DICOM page
                    int[] originalPixels = dicomPage.LoadArgb32Pixels(dicomPage.Bounds);

                    // Build PNG file path for this page
                    string pngPath = Path.Combine(outputDir, $"page_{dicomPage.Index}.png");

                    // Ensure the directory for the PNG exists
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath) ?? ".");

                    // Save the DICOM page as PNG
                    dicomPage.Save(pngPath, new PngOptions());

                    // Load the saved PNG image
                    using (PngImage pngImage = (PngImage)Image.Load(pngPath))
                    {
                        // Load ARGB32 pixel data from the PNG
                        int[] pngPixels = pngImage.LoadArgb32Pixels(pngImage.Bounds);

                        // Compare pixel arrays
                        bool identical = true;
                        if (originalPixels.Length != pngPixels.Length)
                        {
                            identical = false;
                        }
                        else
                        {
                            for (int i = 0; i < originalPixels.Length; i++)
                            {
                                if (originalPixels[i] != pngPixels[i])
                                {
                                    identical = false;
                                    break;
                                }
                            }
                        }

                        // Report result
                        if (identical)
                        {
                            Console.WriteLine($"Page {dicomPage.Index}: Pixel data unchanged after conversion.");
                        }
                        else
                        {
                            Console.WriteLine($"Page {dicomPage.Index}: Pixel data differs after conversion.");
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
 * 1. When a medical imaging application needs to ensure that converting DICOM scans to PNG for web display does not alter the original pixel values.
 * 2. When a radiology workflow requires automated verification that exported PNG thumbnails match the source DICOM pixel data before archiving.
 * 3. When a developer builds a quality‑control tool that compares ARGB32 pixel arrays to detect any loss during format conversion.
 * 4. When integrating Aspose.Imaging into a C# service that validates image fidelity after saving DICOM pages as PNG files.
 * 5. When performing regression testing to confirm that updates to the Aspose.Imaging library keep pixel data unchanged during DICOM‑to‑PNG conversion.
 */
