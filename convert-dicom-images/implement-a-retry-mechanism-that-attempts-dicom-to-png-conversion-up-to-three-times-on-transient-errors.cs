using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = "input.dcm";
        string outputDirectory = "output";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            const int maxAttempts = 3;
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    // Load the DICOM image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Cast to DicomImage to access pages
                        DicomImage dicomImage = image as DicomImage;
                        if (dicomImage == null)
                        {
                            Console.Error.WriteLine("The loaded file is not a DICOM image.");
                            return;
                        }

                        // Iterate through each page and save as PNG
                        foreach (DicomPage page in dicomImage.DicomPages)
                        {
                            string outputPath = Path.Combine(outputDirectory, $"page_{page.Index}.png");

                            // Ensure output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            page.Save(outputPath, new PngOptions());
                        }
                    }

                    // Conversion succeeded, exit retry loop
                    break;
                }
                catch (DicomImageException ex) when (attempt < maxAttempts)
                {
                    // Transient DICOM error, retry
                    // Optionally log the attempt
                    Console.Error.WriteLine($"Transient DICOM error on attempt {attempt}: {ex.Message}");
                }
                catch (IOException ex) when (attempt < maxAttempts)
                {
                    // Transient I/O error, retry
                    Console.Error.WriteLine($"Transient I/O error on attempt {attempt}: {ex.Message}");
                }
                catch (Exception)
                {
                    // Non-transient error, rethrow to outer catch
                    throw;
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
 * 1. When a radiology software needs to convert patient DICOM scans to PNG thumbnails for web preview, handling occasional network or file‑lock errors.
 * 2. When a hospital’s PACS integration script batch‑processes DICOM files into PNG images for inclusion in electronic health records, and must retry on temporary I/O failures.
 * 3. When a medical research application extracts individual DICOM frames as PNGs for machine‑learning preprocessing, requiring a retry loop to survive transient disk latency.
 * 4. When a diagnostic imaging portal generates PNG snapshots of multi‑frame DICOM studies for mobile devices, and needs to automatically retry conversion if the DICOM file is momentarily inaccessible.
 * 5. When a healthcare IT team automates nightly conversion of DICOM archives to PNG for backup verification, and wants to ensure the process retries up to three times on intermittent errors.
 */