// HOW-TO: Batch Convert DICOM to BMP with Gaussian Blur and Resize in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            Directory.CreateDirectory(outputDir);

            var dicomFiles = Directory.GetFiles(inputDir, "*.dcm");
            foreach (var inputPath in dicomFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DicomImage dicomImage = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    // Apply Gaussian blur filter
                    dicomImage.Filter(dicomImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Resize to 640x480 using nearest neighbour resampling
                    dicomImage.Resize(640, 480, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                    // Save as BMP
                    var bmpOptions = new BmpOptions();
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
 * 1. When a medical imaging application must preprocess a folder of DICOM scans by blurring and scaling them before exporting to BMP for legacy viewer compatibility.
 * 2. When a research pipeline needs to automate batch conversion of DICOM files to BMP while applying a Gaussian filter to reduce noise and standardizing the size to 640×480 for machine‑learning input.
 * 3. When a hospital IT system requires a C# script to resize and de‑identify DICOM images with a blur filter before storing them as BMP thumbnails in a PACS archive.
 * 4. When a developer wants to generate uniformly sized BMP assets from a collection of DICOM radiographs for inclusion in a web‑based reporting dashboard.
 * 5. When an imaging workflow must process multiple DICOM files in a directory, apply a Gaussian blur, resize them, and save the results as BMP files using Aspose.Imaging in .NET.
 */
