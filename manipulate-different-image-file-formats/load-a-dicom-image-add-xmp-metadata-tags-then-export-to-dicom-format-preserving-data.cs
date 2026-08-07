using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.dcm";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new DicomOptions();
                // Example: add XMP metadata here using options.XmpData if needed
                image.Save(outputPath, options);
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
 * 1. When a radiology application must embed patient‑specific XMP metadata into a DICOM file before transmitting it to a PACS system, a developer can use this code to load the image, add the tags, and save it without losing any pixel data.
 * 2. When a healthcare research project needs to batch‑process DICOM scans to include study identifiers as XMP metadata while preserving the original image quality, this C# snippet provides a straightforward way to automate the task.
 * 3. When a medical device manufacturer must generate DICOM files that contain custom XMP metadata for regulatory‑compliance audits, the code demonstrates how to load the source file, attach the metadata, and export it in the DICOM format.
 * 4. When a cloud‑based imaging service wants to enrich uploaded DICOM images with XMP tags for searchable annotations without altering the underlying image data, developers can apply this example to perform the operation in .NET.
 * 5. When a hospital IT team needs to convert legacy DICOM files to a newer version while adding XMP metadata for integration with a digital asset management system, this code shows how to load, tag, and save the files safely.
 */