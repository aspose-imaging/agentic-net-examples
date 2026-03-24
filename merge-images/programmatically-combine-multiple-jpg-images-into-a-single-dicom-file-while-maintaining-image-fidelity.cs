using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output DICOM path
        string outputPath = "output.dcm";

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the first image to determine canvas size
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            int width = firstImage.Width;
            int height = firstImage.Height;

            // Prepare DICOM creation options with bound source
            DicomOptions dicomOptions = new DicomOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create DICOM image (first page) with the determined size
            using (DicomImage dicom = (DicomImage)Image.Create(dicomOptions, width, height))
            {
                // Copy pixels of the first JPG onto the first DICOM page
                int[] firstPixels = firstImage.LoadArgb32Pixels(firstImage.Bounds);
                dicom.SaveArgb32Pixels(dicom.Bounds, firstPixels);

                // Process remaining JPG images and add them as additional pages
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                        DicomPage page = dicom.AddPage();
                        page.SaveArgb32Pixels(page.Bounds, pixels);
                    }
                }

                // Save the bound DICOM image (no path needed, already bound to outputPath)
                dicom.Save();
            }
        }
    }
}