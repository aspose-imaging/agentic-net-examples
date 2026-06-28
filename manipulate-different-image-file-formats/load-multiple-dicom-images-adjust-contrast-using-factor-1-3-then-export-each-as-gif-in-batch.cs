using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory and file names
            string inputDir = @"C:\Images\Dicom\";
            string[] inputFiles = new string[]
            {
                "image1.dcm",
                "image2.dcm",
                "image3.dcm"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Images\Gif\";

            foreach (string fileName in inputFiles)
            {
                string inputPath = Path.Combine(inputDir, fileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load DICOM image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to DicomImage to access AdjustContrast
                    DicomImage dicomImage = (DicomImage)image;

                    // Adjust contrast; 30f corresponds to a 30% increase (range -100 to 100)
                    dicomImage.AdjustContrast(30f);

                    // Prepare output path with .gif extension
                    string outputFileName = Path.GetFileNameWithoutExtension(fileName) + ".gif";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as GIF
                    dicomImage.Save(outputPath, new GifOptions());
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
 * 1. When a medical imaging application must convert a set of DICOM scans to lightweight GIF files with increased contrast for quick preview in a web portal.
 * 2. When a radiology research tool needs to batch‑process multiple DICOM images, apply a 30 % contrast boost, and store the results as GIFs for inclusion in presentation slides.
 * 3. When a hospital’s PACS integration script has to automate the export of DICOM files to GIF format while enhancing visibility of details using C# and Aspose.Imaging.
 * 4. When a diagnostic software developer wants to generate GIF images from a series of DICOM slices after adjusting contrast to improve visual analysis.
 * 5. When an e‑learning platform requires a C# routine that loads several DICOM images, raises their contrast by a factor of 1.3, and saves each as a GIF for use in interactive tutorials.
 */