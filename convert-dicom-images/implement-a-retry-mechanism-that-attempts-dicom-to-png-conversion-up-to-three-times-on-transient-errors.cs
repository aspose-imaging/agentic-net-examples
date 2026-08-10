// HOW-TO: Retry DICOM to PNG Conversion Up to Three Times in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.dcm";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            const int maxAttempts = 3;
            int attempt = 0;
            bool success = false;

            while (attempt < maxAttempts && !success)
            {
                try
                {
                    // Load the DICOM image
                    using (Image img = Image.Load(inputPath))
                    {
                        // Cast to DicomImage to access DicomPages
                        DicomImage dicomImage = img as DicomImage;
                        if (dicomImage == null)
                        {
                            Console.Error.WriteLine("The loaded file is not a DICOM image.");
                            return;
                        }

                        // Convert each DICOM page to PNG
                        foreach (DicomPage dicomPage in dicomImage.DicomPages)
                        {
                            string outputPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");
                            // Ensure the directory for the output file exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            dicomPage.Save(outputPath, new PngOptions());
                        }
                    }

                    success = true; // conversion succeeded
                }
                catch (DicomImageException ex)
                {
                    attempt++;
                    if (attempt >= maxAttempts)
                        throw; // rethrow after max attempts
                    // Optionally log transient error
                    Console.Error.WriteLine($"Transient DICOM error (attempt {attempt}): {ex.Message}");
                }
                catch (PngImageException ex)
                {
                    attempt++;
                    if (attempt >= maxAttempts)
                        throw; // rethrow after max attempts
                    // Optionally log transient error
                    Console.Error.WriteLine($"Transient PNG error (attempt {attempt}): {ex.Message}");
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
 * 1. When you need to reliably convert medical DICOM files to PNG images in a C# application, handling occasional read errors.
 * 2. When processing multi‑frame DICOM studies and you must ensure each page is saved as a separate PNG even if the file is temporarily inaccessible.
 * 3. When integrating Aspose.Imaging into a healthcare workflow that requires automatic retries on transient I/O failures during image conversion.
 * 4. When building a batch conversion tool that creates an output folder structure and needs to recover from intermittent network or disk glitches.
 * 5. When converting diagnostic images on a server and you want to guarantee up to three attempts before reporting a failure to the user.
 */
