// HOW-TO: Increase DNG Image Contrast By 30 Percent And Save As TIFF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input/input.dng";
        string outputPath = "output/output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image
            using (Image loadedImage = Image.Load(inputPath))
            {
                DngImage dng = (DngImage)loadedImage;

                int width = dng.Width;
                int height = dng.Height;

                // Load pixel data from DNG
                Color[] pixels = dng.LoadPixels(dng.Bounds);

                // Prepare TIFF options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Create a new TIFF canvas
                using (Image tiffImageBase = Image.Create(tiffOptions, width, height))
                {
                    TiffImage tiff = (TiffImage)tiffImageBase;

                    // Write pixel data to TIFF
                    tiff.SavePixels(tiff.Bounds, pixels);

                    // Adjust contrast by 30%
                    tiff.AdjustContrast(30f);

                    // Save the result as TIFF
                    tiff.Save(outputPath, tiffOptions);
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
 * 1. When you need to enhance the contrast of a raw DNG photo by 30 % before converting it to a high‑resolution TIFF for printing or archival.
 * 2. When a workflow requires automatic adjustment of DNG files’ contrast and saving the results as TIFFs for downstream processing in .NET applications.
 * 3. When you are building a C# tool that prepares camera raw images for medical imaging analysis by increasing contrast and exporting them to TIFF format.
 * 4. When you want to improve the visual clarity of DNG images before performing computer‑vision tasks, using Aspose.Imaging to adjust contrast and output TIFF files.
 * 5. When you need to generate TIFF previews with boosted contrast from DNG assets for web galleries or client review using C# code.
 */
