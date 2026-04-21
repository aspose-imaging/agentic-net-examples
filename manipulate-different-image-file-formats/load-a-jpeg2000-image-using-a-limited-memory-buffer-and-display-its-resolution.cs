using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"c:\temp\sample.jp2";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Configure load options with a limited memory buffer (e.g., 20 MB)
        var loadOptions = new Jpeg2000LoadOptions { BufferSizeHint = 20 };

        // Load the JPEG2000 image using the limited buffer
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Cast to Jpeg2000Image to access resolution properties
            Jpeg2000Image jpeg2000Image = (Jpeg2000Image)image;

            double horizontalResolution = jpeg2000Image.HorizontalResolution;
            double verticalResolution = jpeg2000Image.VerticalResolution;

            Console.WriteLine($"Horizontal resolution: {horizontalResolution} DPI");
            Console.WriteLine($"Vertical resolution: {verticalResolution} DPI");
        }
    }
}