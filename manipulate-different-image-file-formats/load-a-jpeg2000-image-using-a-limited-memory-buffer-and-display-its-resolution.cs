// HOW-TO: Load JPEG2000 Image with Limited Buffer and Get Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jp2";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var loadOptions = new LoadOptions { BufferSizeHint = 10 };
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                Console.WriteLine($"Resolution: {image.Width} x {image.Height}");
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
 * 1. When processing large JPEG2000 files on a server with limited RAM, you can load the image using a small buffer and read its width and height without exhausting memory.
 * 2. When building a thumbnail generator that first needs to know the original image dimensions before scaling, this code lets you retrieve the resolution of a JP2 file efficiently.
 * 3. When validating incoming medical imaging data (often stored as JPEG2000) you can quickly confirm the image size while keeping the memory footprint low.
 * 4. When creating a batch script that logs image metadata for archival purposes, the snippet shows how to read resolution from each JP2 file without loading the full pixel data.
 * 5. When developing a mobile or IoT application that must display image dimensions but cannot afford large buffers, the BufferSizeHint option ensures safe loading of JPEG2000 images.
 */
