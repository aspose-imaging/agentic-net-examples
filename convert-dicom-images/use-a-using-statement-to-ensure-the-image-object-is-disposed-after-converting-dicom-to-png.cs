// HOW-TO: Convert DICOM Image to PNG with Automatic Disposal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output\\converted.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When a healthcare application needs to display radiology scans on a web portal, developers can convert DICOM files to PNG for browser-friendly viewing while ensuring the image object is properly disposed.
 * 2. When integrating medical imaging data into a reporting system that generates PDF documents, developers can transform DICOM images to PNG before embedding them, using a using block to manage resources.
 * 3. When building a batch processing tool that archives patient scans as lossless PNG files, developers can load each DICOM file, save it as PNG, and rely on the using statement to prevent memory leaks.
 * 4. When creating a desktop viewer that allows clinicians to zoom and annotate scans, developers can convert DICOM to PNG on the fly, using Aspose.Imaging to handle the conversion and automatically release the image handle.
 * 5. When developing a cloud service that receives DICOM uploads and returns PNG thumbnails for preview, developers can employ this code to perform the conversion safely within a disposable context.
 */
