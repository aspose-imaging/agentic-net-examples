using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                image.Rotate(90);

                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, saveOptions);
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
 * 1. When a C# application must rotate a multi‑gigabyte TIFF file without exhausting system RAM, developers can set ImageOptions.MemoryUsageLimit to 200 MB to keep the operation within safe memory bounds.
 * 2. When processing high‑resolution scanned documents in a batch job, using Aspose.Imaging’s TiffOptions with a 200 MB memory limit prevents out‑of‑memory exceptions while saving the rotated output.
 * 3. When integrating a document management system that receives large TIFF uploads, developers can apply a 200 MB MemoryUsageLimit to ensure the server can rotate and store the image without crashing.
 * 4. When building a .NET microservice that converts legacy TIFF archives to a new orientation, setting ImageOptions.MemoryUsageLimit to 200 MB allows the service to handle each file efficiently under constrained container memory.
 * 5. When creating a desktop utility for photographers to quickly re‑orient massive TIFF panoramas, configuring the memory usage limit to 200 MB lets the tool rotate images on modest hardware without performance degradation.
 */