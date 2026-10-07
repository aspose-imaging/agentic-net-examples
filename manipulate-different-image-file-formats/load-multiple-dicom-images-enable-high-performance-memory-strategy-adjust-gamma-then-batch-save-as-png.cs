// HOW-TO: Batch Convert DICOM to PNG with Gamma Adjustment in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add DICOM files and rerun.");
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

                LoadOptions loadOptions = new LoadOptions { BufferSizeHint = 10 * 1024 * 1024 };
                using (RasterImage image = (RasterImage)Image.Load(inputPath, loadOptions))
                {
                    image.AdjustGamma(1.2f);

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        image.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application needs to export a series of DICOM scans as PNG files for web viewing while improving brightness with gamma correction.
 * 2. When a radiology workflow requires fast loading of large DICOM files by using a memory buffer hint to reduce processing time.
 * 3. When a research project must batch process DICOM images and store them in a lossless PNG format for inclusion in publications.
 * 4. When a hospital IT system wants to convert patient scan files to PNG for integration with a third‑party viewer that does not support DICOM.
 * 5. When a developer needs to automate the conversion of multiple DICOM files to PNG with consistent gamma settings as part of a data‑preparation pipeline.
 */
