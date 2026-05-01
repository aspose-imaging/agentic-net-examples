using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare BMP save options
                BmpOptions bmpOptions = new BmpOptions();

                // Save ODG to a memory stream as BMP
                using (MemoryStream ms = new MemoryStream())
                {
                    odgImage.Save(ms, bmpOptions);
                    ms.Position = 0; // Reset stream position for reading

                    // Load the BMP from the memory stream
                    using (BmpImage bmpImage = new BmpImage(ms))
                    {
                        // Set custom resolution to 150 DPI
                        bmpImage.SetResolution(150.0, 150.0);

                        // Save the final BMP file
                        bmpImage.Save(outputPath);
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