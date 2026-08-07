using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.dcm";
        string outputPath = @"C:\Temp\sample_converted.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image dicomImage = Image.Load(inputPath))
            {
                // Save the first page (or only page) as PNG
                // For multi‑page DICOM, we take the active page (default is first)
                dicomImage.Save(outputPath, new PngOptions());

                // Extract pixel data from the original DICOM image
                int[] originalPixels = ((RasterImage)dicomImage).LoadArgb32Pixels(dicomImage.Bounds);

                // Load the saved PNG image
                using (Image pngImage = Image.Load(outputPath))
                {
                    // Extract pixel data from the PNG image
                    int[] pngPixels = ((RasterImage)pngImage).LoadArgb32Pixels(pngImage.Bounds);

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
                        Console.WriteLine("Pixel data is unchanged after conversion.");
                    }
                    else
                    {
                        Console.WriteLine("Pixel data differs after conversion.");
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
 * 1. When a medical imaging application needs to create PNG thumbnails of DICOM scans for quick preview while guaranteeing that the original pixel values remain unchanged.
 * 2. When a hospital PACS system converts DICOM files to PNG for web‑based viewers and must validate that the conversion does not alter any diagnostic pixel data.
 * 3. When a research team extracts pixel arrays from DICOM images, saves them as PNG for machine‑learning pipelines, and wants to ensure the PNG representation is pixel‑identical to the source.
 * 4. When a compliance audit requires proof that converting DICOM to PNG does not modify pixel intensity values used in quantitative analysis.
 * 5. When an automated batch job processes large volumes of DICOM images into PNG format and includes a pixel‑by‑pixel comparison to detect any loss of information before release.
 */