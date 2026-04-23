using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\temp\sample.jp2";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Set up JPEG2000 load options with a limited memory buffer (e.g., 1 MB)
            var loadOptions = new Jpeg2000LoadOptions
            {
                BufferSizeHint = 1024 * 1024 // 1 MB buffer size hint
            };

            // Load the JPEG2000 image using the specified options
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Cast to Jpeg2000Image to access resolution properties
                var jpeg2000Image = (Jpeg2000Image)image;

                // Display horizontal and vertical resolution (pixels per inch)
                Console.WriteLine($"Horizontal resolution: {jpeg2000Image.HorizontalResolution} DPI");
                Console.WriteLine($"Vertical resolution: {jpeg2000Image.VerticalResolution} DPI");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}