// HOW-TO: Set BMP Image DPI to 300 for High Resolution Printing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output_300dpi.bmp";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to BmpImage to access SetResolution
                BmpImage bmpImage = (BmpImage)image;

                // Set DPI to 300x300
                bmpImage.SetResolution(300.0, 300.0);

                // Save the modified image
                bmpImage.Save(outputPath);
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
 * 1. When preparing a BMP file for a commercial printer that requires 300 DPI, you can use this code to update the image’s resolution metadata before sending it to the press.
 * 2. When converting scanned documents saved as BMP to meet archival standards that mandate 300 DPI, the snippet ensures the DPI tag is corrected without altering pixel data.
 * 3. When generating high‑resolution product labels in a C# application, you can set the BMP’s DPI to 300 so the printed label appears sharp and correctly sized.
 * 4. When integrating Aspose.Imaging into a workflow that batches BMP assets for a marketing campaign, this code lets you uniformly enforce a 300 DPI setting across all images.
 * 5. When troubleshooting mismatched image sizes in a desktop publishing system, you can programmatically adjust the BMP DPI to 300 to align the on‑screen layout with the intended print dimensions.
 */
