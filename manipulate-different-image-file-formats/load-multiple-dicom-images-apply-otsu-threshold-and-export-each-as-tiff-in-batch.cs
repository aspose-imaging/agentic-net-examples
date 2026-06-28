using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tiff");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    DicomImage dicomImage = (DicomImage)image;
                    dicomImage.BinarizeOtsu();

                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When a radiology software needs to convert a folder of DICOM scans into high‑contrast TIFF files for archival or downstream analysis, this code can batch‑process the images using Aspose.Imaging’s Otsu binarization.
 * 2. When a research lab wants to prepare a set of DICOM ultrasound images for machine‑learning training by applying Otsu thresholding and exporting them as TIFFs in a single C# script, this example provides the needed workflow.
 * 3. When a hospital PACS integration requires automated conversion of incoming DICOM files to TIFF format with binary segmentation for printing or reporting, developers can use this code to handle the conversion in bulk.
 * 4. When a medical‑device manufacturer needs to generate TIFF‑compatible test assets from DICOM reference images while applying Otsu threshold to highlight regions of interest, this snippet performs the batch conversion in .NET.
 * 5. When a developer is building a C# utility that scans a directory of DICOM files, applies Otsu threshold to each image, and saves the results as TIFFs for compliance documentation, this example shows the complete process.
 */