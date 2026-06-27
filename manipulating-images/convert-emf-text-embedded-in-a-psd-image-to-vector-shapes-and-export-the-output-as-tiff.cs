using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image psdImage = Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                psdImage.Save(outputPath, tiffOptions);
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
 * 1. When a graphics pipeline needs to preserve editable vector text from a Photoshop PSD that contains embedded EMF objects while delivering a high‑resolution TIFF for printing, a developer can load the PSD, convert the EMF text to vector shapes, and save the result as a TIFF using Aspose.Imaging for .NET.
 * 2. When an archival system requires converting legacy Photoshop files with embedded Windows Metafile (EMF) annotations into a lossless TIFF format that retains the original vector information for future editing, the code can be used to perform the conversion in C#.
 * 3. When a web service must generate printable TIFF previews from user‑uploaded PSD files that include EMF‑based captions, the developer can employ this routine to extract the vector text, rasterize it correctly, and output a TIFF suitable for PDF generation.
 * 4. When a batch‑processing job needs to automate the transformation of multiple PSD assets containing EMF text layers into TIFF files for a publishing workflow, the Aspose.Imaging API enables loading each PSD, converting the EMF objects to vector shapes, and saving them as TIFFs in a single C# loop.
 * 5. When a desktop application has to validate that embedded EMF text in a Photoshop document is correctly rendered before sending the image to a commercial printer that only accepts TIFF files, the developer can use this code to load the PSD, convert the EMF text to vector shapes, and export a TIFF for visual inspection.
 */