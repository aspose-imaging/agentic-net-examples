using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input DICOM files
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input1.dcm",
                @"C:\Images\Input2.dcm",
                @"C:\Images\Input3.dcm"
            };

            // Corresponding output GIF files
            string[] outputPaths = new string[]
            {
                @"C:\Images\Output1.gif",
                @"C:\Images\Output2.gif",
                @"C:\Images\Output3.gif"
            };

            // Process each file
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DICOM image, adjust contrast, and save as GIF
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to DicomImage to access AdjustContrast
                    DicomImage dicomImage = (DicomImage)image;

                    // Adjust contrast by a factor of 1.3.
                    // The method expects a value in [-100,100]; 30 corresponds to ~1.3 factor.
                    dicomImage.AdjustContrast(30f);

                    // Save the processed image as GIF
                    GifOptions gifOptions = new GifOptions();
                    dicomImage.Save(outputPath, gifOptions);
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
 * 1. When a medical imaging application must batch‑convert a series of DICOM scans to lightweight GIF files for fast web preview while boosting visibility with a 1.3 contrast increase.
 * 2. When a radiology research team needs to process multiple CT slice DICOM images, apply a contrast factor of 1.3, and save the results as GIFs for inclusion in slide decks or reports.
 * 3. When a hospital PACS integration automates the conversion of incoming DICOM files to GIF format with adjusted contrast to improve readability on mobile and browser‑based viewers.
 * 4. When a healthcare analytics pipeline extracts DICOM images, normalizes their contrast, and exports them as GIFs so downstream machine‑learning models that accept only common image formats can consume them.
 * 5. When a telemedicine portal generates thumbnail GIFs from several DICOM files with enhanced contrast to give physicians a quick visual overview before loading the full study.
 */