using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string[] inputPaths = {
            @"C:\Images\Input1.dcm",
            @"C:\Images\Input2.dcm",
            @"C:\Images\Input3.dcm"
        };

        string[] outputPaths = {
            @"C:\Processed\Output1.bmp",
            @"C:\Processed\Output2.bmp",
            @"C:\Processed\Output3.bmp"
        };

        // Process each DICOM image
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

            // Load, process, and save the image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Apply Gaussian blur filter to the entire image
                dicomImage.Filter(
                    dicomImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Resize to 640x480 using nearest neighbour resampling
                dicomImage.Resize(640, 480, ResizeType.NearestNeighbourResample);

                // Save as BMP
                dicomImage.Save(outputPath, new BmpOptions());
            }
        }
    }
}