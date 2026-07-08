using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cmx";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                cmx.HasBackgroundColor = true;
                cmx.BackgroundColor = Color.White; // custom background color

                Source source = new FileCreateSource(outputPath, false);
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = source,
                    Quality = 100
                };

                cmx.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to embed legacy CorelDRAW CMX artwork into a web page that only supports JPEG images, they can use this code to convert the CMX file to a high‑quality JPEG while applying a white background to replace transparent areas and prevent visual artifacts.
 * 2. When an automated document‑processing pipeline receives CMX files from external partners and must generate thumbnail previews in JPEG format for a content management system, the code provides a reliable way to perform the conversion and set a custom background color for any transparent regions.
 * 3. When a desktop application that creates printable reports must include vector graphics originally saved as CMX, the developer can convert them to JPEG with a specified background (e.g., white or corporate brand color) to ensure consistent appearance on printers that do not support CMX transparency.
 * 4. When a batch‑conversion utility needs to migrate a large archive of CMX assets to JPEG for archival storage while preserving visual fidelity, this snippet shows how to load each CMX image, assign a background color, and save it with maximum JPEG quality.
 * 5. When integrating Aspose.Imaging into a C# service that receives user‑uploaded CMX files and returns a JPEG preview for mobile devices, the code demonstrates how to handle missing files, create the output directory, and replace transparent pixels with a chosen background to avoid unwanted artifacts.
 */