using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DICOM file and output directory
            string inputPath = "input.dcm";
            string outputDirectory = "output";

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

                    // Define PNG file path for this page
                    string pngPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");

                    // Ensure directory for PNG exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                    // Save the DICOM page as PNG
                    dicomPage.Save(pngPath, new PngOptions());

                    // Load the saved PNG image
                    using (PngImage pngImage = (PngImage)Image.Load(pngPath))
                    {
                        // Load ARGB32 pixel data from the PNG image
                        int[] pngPixels = pngImage.LoadArgb32Pixels(pngImage.Bounds);

                        // Compare pixel arrays
                        bool pixelsUnchanged = originalPixels.Length == pngPixels.Length &&
                                               originalPixels.SequenceEqual(pngPixels);

                        Console.WriteLine($"Page {dicomPage.Index}: pixel data unchanged = {pixelsUnchanged}");
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