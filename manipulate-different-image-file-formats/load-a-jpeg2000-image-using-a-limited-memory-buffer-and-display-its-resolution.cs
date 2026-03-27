using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.jp2";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Configure load options with a limited memory buffer (e.g., 20 MB)
        var loadOptions = new Jpeg2000LoadOptions
        {
            BufferSizeHint = 20 // buffer size in megabytes
        };

        // Load the JPEG2000 image using the specified load options
        using (Jpeg2000Image jpeg2000Image = (Jpeg2000Image)Image.Load(inputPath, loadOptions))
        {
            // Display horizontal and vertical resolution (DPI)
            Console.WriteLine($"Horizontal resolution: {jpeg2000Image.HorizontalResolution} DPI");
            Console.WriteLine($"Vertical resolution: {jpeg2000Image.VerticalResolution} DPI");
        }
    }
}