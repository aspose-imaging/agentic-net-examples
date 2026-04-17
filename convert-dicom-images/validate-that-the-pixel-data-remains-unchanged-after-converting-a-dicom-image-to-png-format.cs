using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Process only the first page for comparison
            var dicomPage = dicomImage.DicomPages[0];

            // Load pixel data from the DICOM page (ARGB32 format)
            int[] originalPixels = dicomPage.LoadArgb32Pixels(dicomPage.Bounds);

            // Save the page as a PNG file
            dicomPage.Save(outputPath, new PngOptions());

            // Load the saved PNG image
            using (PngImage pngImage = (PngImage)Image.Load(outputPath))
            {
                // Load pixel data from the PNG image (ARGB32 format)
                int[] pngPixels = pngImage.LoadArgb32Pixels(pngImage.Bounds);

                // Compare pixel arrays
                bool identical = true;
                if (originalPixels.Length != pngPixels.Length)
                {
                    identical = false;
                }
                else
                {
                    for (int i = 0; i < originalPixels.Length; i++)
                    {
                        if (originalPixels[i] != pngPixels[i])
                        {
                            identical = false;
                            break;
                        }
                    }
                }

                // Output result
                if (identical)
                {
                    Console.WriteLine("Pixel data is unchanged after conversion.");
                }
                else
                {
                    Console.WriteLine("Pixel data differs after conversion.");
                }
            }
        }
    }
}