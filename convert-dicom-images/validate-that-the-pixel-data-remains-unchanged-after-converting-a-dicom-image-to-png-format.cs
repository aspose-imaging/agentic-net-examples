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
        try
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

            // Load DICOM image
            using (var dicomImage = Image.Load(inputPath) as DicomImage)
            {
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("Failed to load DICOM image.");
                    return;
                }

                // Extract pixel data from the first page (or the whole image if single page)
                int[] originalPixels = dicomImage.LoadArgb32Pixels(dicomImage.Bounds);

                // Save as PNG
                dicomImage.Save(outputPath, new PngOptions());

                // Load the saved PNG image
                using (var pngImage = Image.Load(outputPath) as PngImage)
                {
                    if (pngImage == null)
                    {
                        Console.Error.WriteLine("Failed to load PNG image.");
                        return;
                    }

                    // Extract pixel data from PNG
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
                        Console.WriteLine("Pixel data unchanged after conversion.");
                    else
                        Console.WriteLine("Pixel data differs after conversion.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}