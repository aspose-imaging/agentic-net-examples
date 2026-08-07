using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Input\sample.eps";
            string outputPath = @"C:\Output\sample.tif";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare default TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a print shop needs to convert customer‑submitted EPS artwork into high‑resolution TIFF files for pre‑press workflows, they can use this code to load the EPS and save it as TIFF in one step.
 * 2. When a document management system must archive vector EPS drawings as lossless TIFF images for compatibility with legacy scanners and viewers, the snippet provides a C# solution to perform the conversion automatically.
 * 3. When a web service receives EPS files via upload and must generate TIFF thumbnails for preview in a browser, developers can employ this code to load the EPS and export it directly to TIFF.
 * 4. When a batch‑processing tool needs to migrate a folder of EPS logos into TIFF format for inclusion in PDF reports, the example shows how to verify file existence, create output directories, and save each image using Aspose.Imaging.
 * 5. When an automated testing framework validates that EPS files render correctly by comparing them to reference TIFF images, this code enables loading the EPS and saving it as TIFF for pixel‑by‑pixel comparison.
 */