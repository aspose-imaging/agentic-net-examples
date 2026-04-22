using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Iterate through each DICOM page
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Load original ARGB32 pixel data from the DICOM page
                    int[] originalPixels = dicomPage.LoadArgb32Pixels(dicomPage.Bounds);

                    // Prepare PNG output path for this page
                    string pngPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");

                    // Ensure the directory for the PNG file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                    // Save the DICOM page as PNG
                    dicomPage.Save(pngPath, new PngOptions());

                    // Load the saved PNG image
                    using (PngImage pngImage = (PngImage)Image.Load(pngPath))
                    {
                        // Load ARGB32 pixel data from the PNG image
                        int[] pngPixels = pngImage.LoadArgb32Pixels(pngImage.Bounds);

                        // Compare pixel data
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

                        // Report result
                        if (identical)
                        {
                            Console.WriteLine($"Page {dicomPage.Index}: pixel data unchanged after conversion.");
                        }
                        else
                        {
                            Console.WriteLine($"Page {dicomPage.Index}: pixel data mismatch after conversion.");
                        }
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