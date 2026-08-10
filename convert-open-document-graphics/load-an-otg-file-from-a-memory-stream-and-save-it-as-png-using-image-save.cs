// HOW-TO: Convert OTG File to PNG from Memory Stream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.otg";
        string outputPath = "output.png";

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

            // Load OTG file into a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                // Wrap the memory stream in a StreamContainer required by OtgImage
                using (StreamContainer streamContainer = new StreamContainer(memoryStream))
                {
                    // Create OtgImage from the stream container
                    using (OtgImage otgImage = new OtgImage(streamContainer))
                    {
                        // Prepare PNG save options with OTG rasterization settings
                        PngOptions pngOptions = new PngOptions();
                        OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                        {
                            PageSize = otgImage.Size
                        };
                        pngOptions.VectorRasterizationOptions = rasterOptions;

                        // Save the image as PNG
                        otgImage.Save(outputPath, pngOptions);
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

/*
 * Real-World Use Cases:
 * 1. When you need to display or embed an OpenDocument graphic (OTG) in a web page that only supports PNG images, you can load the OTG from a byte array and save it as PNG.
 * 2. When processing uploaded OTG files in an ASP.NET API without writing them to disk, you can read the file into a MemoryStream and convert it to PNG for further processing.
 * 3. When generating thumbnails for OTG documents stored in a database BLOB, you can rasterize the vector content via OtgRasterizationOptions and save the result as a PNG image.
 * 4. When integrating Aspose.Imaging into a background service that converts batch OTG files to PNG for archival or reporting purposes, you can stream each file and use Image.Save to produce the PNG output.
 * 5. When creating a cross‑platform C# utility that converts OTG diagrams to PNG for use in mobile apps, loading the file from memory avoids temporary files and speeds up the conversion.
 */
