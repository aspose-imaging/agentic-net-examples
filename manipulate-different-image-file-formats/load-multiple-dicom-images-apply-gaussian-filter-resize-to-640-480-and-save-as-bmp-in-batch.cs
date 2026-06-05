using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] files = Directory.GetFiles(inputDir, "*.dcm");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    DicomImage dicomImage = (DicomImage)image;

                    dicomImage.Resize(640, 480, ResizeType.NearestNeighbourResample);

                    dicomImage.Save(outputPath, new BmpOptions());
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
 * 1. When a medical imaging application needs to convert a folder of DICOM scans into 640×480 BMP thumbnails for quick preview in a web portal.
 * 2. When a radiology workflow requires batch processing of DICOM files to standardize image dimensions before archiving them in a BMP format compatible with legacy PACS systems.
 * 3. When a research project must extract DICOM images from a scanner output directory, resize them for inclusion in a machine‑learning dataset, and store them as BMP files for consistent pixel format.
 * 4. When a hospital IT team wants to automate the creation of BMP copies of DICOM studies for printing on non‑DICOM‑aware printers.
 * 5. When a developer builds a C# utility that scans an input folder, loads each DICOM image, resizes it to 640×480, and saves the result as BMP to simplify downstream image analysis tools.
 */