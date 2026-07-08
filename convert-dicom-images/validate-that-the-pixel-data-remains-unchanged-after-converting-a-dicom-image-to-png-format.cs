using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image and capture original pixel data
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;
                int[] originalPixels = dicomImage.LoadArgb32Pixels(dicomImage.Bounds);

                // Save as PNG
                dicomImage.Save(outputPath, new PngOptions());

                // Load saved PNG and capture its pixel data
                using (Image pngImage = Image.Load(outputPath))
                {
                    var raster = (RasterImage)pngImage;
                    int[] pngPixels = raster.LoadArgb32Pixels(raster.Bounds);

                    // Compare pixel arrays
                    bool identical = originalPixels.Length == pngPixels.Length;
                    if (identical)
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

                    if (identical)
                    {
                        Console.WriteLine("Pixel data unchanged after conversion.");
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
 * 1. When a medical imaging application generates PNG thumbnails of DICOM scans for web preview and must ensure the visual fidelity of the original pixel data.
 * 2. When a hospital’s PACS integration validates that exported PNG reports match the source DICOM images before archiving them in an electronic health record system.
 * 3. When a research workflow converts DICOM MRI datasets to PNG for machine‑learning preprocessing and needs to confirm that no pixel values were altered during the conversion.
 * 4. When a diagnostic device manufacturer runs a quality‑control test that checks the consistency of pixel data after converting DICOM images to PNG for patient‑friendly printouts.
 * 5. When a telemedicine platform automates the conversion of DICOM radiology images to PNG for mobile viewing and must verify that the conversion preserves the exact pixel intensities.
 */