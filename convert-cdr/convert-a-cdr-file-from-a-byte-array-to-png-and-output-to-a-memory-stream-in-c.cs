using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Example byte array containing CDR data.
            // Replace with actual CDR file bytes.
            byte[] cdrData = new byte[0];

            using (MemoryStream inputStream = new MemoryStream(cdrData))
            {
                using (CdrImage cdrImage = new CdrImage(inputStream, new LoadOptions()))
                {
                    // Ensure the image data is fully loaded.
                    cdrImage.CacheData();

                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions();

                        // Save the CDR image as PNG into the memory stream.
                        cdrImage.Save(outputStream, pngOptions);

                        // Output the size of the generated PNG data.
                        Console.WriteLine($"PNG data size: {outputStream.Length} bytes");
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