// HOW-TO: Batch Convert DICOM to BMP with Gaussian Blur and Resize in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
                {
                    dicom.Filter(dicom.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));
                    dicom.Resize(640, 480);

                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        dicom.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging application needs to preprocess a series of DICOM scans by smoothing and resizing them before converting to BMP for display in a Windows viewer.
 * 2. When a radiology workflow requires batch conversion of DICOM files to a universally supported bitmap format while applying a Gaussian blur to reduce noise.
 * 3. When a research project must standardize image dimensions (640×480) and apply a blur filter to DICOM images before feeding them into a machine‑learning model that only accepts BMP inputs.
 * 4. When a hospital IT system needs to archive DICOM studies as BMP thumbnails with consistent size and softened edges for quick preview in a web portal.
 * 5. When a developer wants to automate the processing of multiple DICOM files, applying a Gaussian filter and resizing them in one pass, then saving the results as BMP files for downstream legacy software.
 */
