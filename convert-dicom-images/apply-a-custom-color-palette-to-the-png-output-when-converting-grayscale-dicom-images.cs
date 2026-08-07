using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.dcm";
            string outputPath = "C:\\temp\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Convert to grayscale if not already
                if (image is DicomImage dicomImage)
                {
                    dicomImage.Grayscale();
                }

                // Configure PNG options with a custom grayscale palette
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false)
                };

                // Save the image as PNG using the custom palette
                image.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application must export DICOM scans as PNG files with a standardized 8‑bit grayscale palette for consistent display across web browsers.
 * 2. When a radiology workflow needs to generate lightweight PNG thumbnails from large DICOM series while preserving exact grayscale tones using a custom palette.
 * 3. When a hospital PACS integration requires converting DICOM images to indexed‑color PNGs to meet legacy system constraints that only accept palette‑based PNGs.
 * 4. When a research project processes DICOM brain MRI data and needs to save the results as PNGs with a non‑default grayscale palette to match published figure guidelines.
 * 5. When a diagnostic software tool automates batch conversion of DICOM files to PNG and must ensure the output uses a specific 8‑bit grayscale palette for accurate pixel intensity mapping.
 */