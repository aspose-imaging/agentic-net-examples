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
            // Define input DICOM files and corresponding output GIF files
            string[] inputPaths = {
                @"C:\Images\input1.dcm",
                @"C:\Images\input2.dcm"
            };

            string[] outputPaths = {
                @"C:\Images\output1.gif",
                @"C:\Images\output2.gif"
            };

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

                // Load DICOM image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to DicomImage to access AdjustContrast
                    DicomImage dicomImage = (DicomImage)image;

                    // Adjust contrast by a factor of 1.3 (30% increase)
                    dicomImage.AdjustContrast(30f);

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