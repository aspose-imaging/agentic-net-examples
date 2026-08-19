// HOW-TO: Log Aspose Imaging Exceptions When Converting DICOM to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.CoreExceptions.ImageFormats;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access pages
                DicomImage dicomImage = image as DicomImage;
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not a DICOM image.");
                    return;
                }

                int pageIndex = 0;
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Build output file path for each page
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    try
                    {
                        // Save the page as PNG
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                    catch (DicomImageException ex)
                    {
                        Console.Error.WriteLine($"DicomImageException on page {pageIndex}: {ex.Message}");
                    }
                    catch (ImageSaveException ex)
                    {
                        Console.Error.WriteLine($"ImageSaveException on page {pageIndex}: {ex.Message}");
                    }
                    catch (PngImageException ex)
                    {
                        Console.Error.WriteLine($"PngImageException on page {pageIndex}: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Unexpected error on page {pageIndex}: {ex.Message}");
                    }

                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any other unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to convert each frame of a DICOM file to separate PNG files while handling corrupted data gracefully.
 * 2. When a batch processing script must verify the existence of DICOM files and create output directories before conversion.
 * 3. When developers want to capture and log specific Aspose.Imaging exceptions such as DicomImageException during page‑wise conversion.
 * 4. When an integration pipeline requires safe fallback behavior if a DICOM page cannot be saved as PNG due to image format issues.
 * 5. When a diagnostic tool needs to continue processing remaining pages after a failure on one page, ensuring partial results are still generated.
 */
