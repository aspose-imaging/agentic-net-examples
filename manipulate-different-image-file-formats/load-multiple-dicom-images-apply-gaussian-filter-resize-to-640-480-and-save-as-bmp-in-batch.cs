using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "InputDICOM";
            string outputDir = "OutputBMP";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add DICOM files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] inputFiles = Directory.GetFiles(inputDir, "*.dcm");

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
                {
                    dicomImage.Filter(dicomImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                    dicomImage.Resize(640, 480, ResizeType.NearestNeighbourResample);
                    BmpOptions bmpOptions = new BmpOptions();
                    dicomImage.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging application must convert a batch of DICOM scans into BMP files for integration with legacy Windows picture viewers, applying a Gaussian blur to reduce noise and resizing to 640×480 for uniform display.
 * 2. When a radiology research pipeline needs to preprocess thousands of DICOM images by smoothing, scaling them to a standard resolution, and exporting to BMP format for use in machine‑learning models that accept only bitmap inputs.
 * 3. When a hospital’s PACS system requires an automated nightly job that extracts DICOM files, applies a Gaussian filter to enhance visual quality, resizes them for quick web preview, and saves them as BMPs for fast loading in a web portal.
 * 4. When a developer is building a C# utility to prepare DICOM images for printing on standard office printers, needing to blur artifacts, resize to 640×480, and output BMP files compatible with the printer driver.
 * 5. When a healthcare software vendor wants to create a lightweight image viewer that reads DICOM files, applies a Gaussian blur for noise reduction, resizes them for consistent UI layout, and stores the results as BMPs for caching and faster retrieval.
 */